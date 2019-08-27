    function validarCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf == '') return false;
    // Elimina CPFs invalidos conhecidos
    if (cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999")
        return false;
    // Valida 1o digito
    add = 0;
    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(9)))
        return false;
    // Valida 2o digito
    add = 0;
    for (i = 0; i < 10; i++)
        add += parseInt(cpf.charAt(i)) * (11 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(10)))
        return false;
    return true;
}
function Limpar() {
    $(".is-invalid").removeClass("is-invalid");
    $(".is-valid").removeClass("is-valid");
    $("#id").val("");
    $("#cpf").val("");
    $("#nome").val("");
    $("#email").val("");
    $("#data_nascimento").val("");
    $("#telefone").val("");
    $("#cep").val("");
    $("#cidade").val("");
    $("#bairro").val("");
    $("#rua").val("");
    $("#numero").val("");
    $("#complemento").val("");
    $("#observacao").val("");
}
function fMasc(objeto, mascara) {
    obj = objeto
    masc = mascara
    setTimeout("fMascEx()", 1)
}
function fMascEx() {
    obj.value = masc(obj.value)
}
function FormatarDataPadraoParaIngles(date) {
    var data = date.split("-");
    var ano = data[0];
    var mes = data[1];
    var dia = data[2];
    dia = dia.slice(0, 2);
    date = ano + "-" + mes + "-" + dia;

    return date;
}
function FormatarDataInglesParaPadrao(date) {
    var data = date.split("-");
    var dia = data[0];
    var mes = data[1];
    var ano = data[2];

    date = dia + "/" + mes + "/" + ano;

    return date;
}
function mCPF(cpf) {
    cpf = cpf.replace(/\D/g, "")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
    if ($('#cpf').addClass('is-valid')) {
        $('#cpf').removeClass('is-valid');
    }
    $('#cpf').addClass('is-invalid');
    if (cpf.length == 14) {
        $("#carregando").html('<i class="fas fa-spinner fa-spin">');
        var dado = {
            Cpf: cpf,
        };
        if (validarCPF(cpf)) {
            var str = cpf;
            $.ajax({
                type: 'POST',
                url: '/Usuario/BuscarPorCpf',
                data: { str },
                success: function (data) {
                    if (data.pessoa != null) {
                        $("#id").val(data.pessoa.id);
                        $("#nome").val(data.pessoa.nome);
                        $("#email").val(data.pessoa.email);
                        date = FormatarDataPadraoParaIngles(data.pessoa.dataNascimento);
                        $("#data_nascimento").val(date);
                        $("#telefone").val(data.pessoa.telefone);
                        $("#cep").val(data.pessoa.endereco.cep);
                        $("#cidade").val(data.pessoa.endereco.cidade);
                        $("#bairro").val(data.pessoa.endereco.bairro);
                        $("#rua").val(data.pessoa.endereco.rua);
                        $("#numero").val(data.pessoa.endereco.numero);
                        $("#complemento").val(data.pessoa.endereco.complemento);
                        if (data.pessoa.socio == 0) {
                            $(".socio option[value='1']").attr('selected', 'selected');
                        }
                        if (data.pessoa.jogador == 0) {
                            $(".jogador option[value='1']").attr('selected', 'selected');
                        }

                        $("#observacoes").val(data.pessoa.observacoes);
                        if (data.pessoa.isento == 0) {
                            $("#isento").prop("checked", false);
                        }
                        else {
                            $("#isento").prop("checked", true);
                        }

                        if ($('#cpf').hasClass('is-invalid')) {
                            $('#cpf').addClass('is-valid');
                            $('#cpf').removeClass('is-invalid');
                        }
                        $("#f1").removeAttr('disabled');
                        $("#f2").removeAttr('disabled');
                        $("#f3").removeAttr('disabled');
                    }
                    else {
                        if ($('#cpf').hasClass('is-invalid')) {
                            $('#cpf').addClass('is-valid');
                            $('#cpf').removeClass('is-invalid');
                        }
                        $("#f1").removeAttr('disabled');
                        $("#f2").removeAttr('disabled');
                        $("#f3").removeAttr('disabled');
                    }
                    $("#carregando").html('');
                },
                error: function (data) {
                    $('#Erro').modal('show');
                    $('#titulo').html("Ops... Ocorreu um erro!");
                    $('#corpo').html("Tente novamente.");
                    $("#carregando").html('');
                }
            });
        }
    }
    $("#carregando").html('');
    return cpf
}
function mTel(tel) {
    tel = tel.replace(/\D/g, "")
    tel = tel.replace(/^(\d)/, "($1")
    tel = tel.replace(/(.{3})(\d)/, "$1)$2")
    if (tel.length == 9) {
        tel = tel.replace(/(.{1})$/, "-$1")
    } else if (tel.length == 10) {
        tel = tel.replace(/(.{2})$/, "-$1")
    } else if (tel.length == 11) {
        tel = tel.replace(/(.{3})$/, "-$1")
    } else if (tel.length == 12) {
        tel = tel.replace(/(.{4})$/, "-$1")
    } else if (tel.length > 12) {
        tel = tel.replace(/(.{4})$/, "-$1")
    }
    validaTelefone();
    return tel;
}
function mCEP(cep) {
    cep = cep.replace(/\D/g, "")
    cep = cep.replace(/^(\d{2})(\d)/, "$1.$2")
    cep = cep.replace(/\.(\d{3})(\d)/, ".$1-$2")
    validaCep();
    if (cep.length == 10) {
        usuario.buscarCep(cep)

        $("#f2").removeAttr('disabled');
    }
    return cep
}
function gravar() {
    var isento;
    var form = {
        id: $("#id").val(),
        cpf: $("#cpf").val(),
        nome: $("#nome").val(),
        email: $("#email").val(),
        dataNascimento: $("#data_nascimento").val(),
        telefone: $("#telefone").val(),
        cep: $("#cep").val(),
        cidade: $("#cidade").val(),
        bairro: $("#bairro").val(),
        rua: $("#rua").val(),
        numero: $("#numero").val(),
        complemento: $("#complemento").val(),
        socio: $("#socio :selected").val(),
        jogador: $("#jogador :selected").val(),
        observacoes: $("#observacao").val(),
        pendenciaId: "0",
    };
    if ($("#isento").is(':checked')) {
        isento = 1;
    }
    $.ajax({
        type: 'POST',
        url: '/Usuario/Gravar',
        data: { Id: form.id, Cpf: form.cpf, Nome: form.nome, Email: form.email, DataNascimento: form.dataNascimento, Telefone: form.telefone, Cep: form.cep, Cidade: form.cidade, Bairro: form.bairro, Rua: form.rua, Numero: form.numero, Complemento: form.complemento, Socio: form.socio, Jogador: form.jogador, Observacoes: form.observacoes, Isento: isento, PendenciaId: form.pendenciaId },
        success: function (result) {
            if (result.erros[0] == 100) {


                window.location.href = "/Usuario/Lista";
            }
            else {
                $('#Erro').modal('show');
                $('#titulo').html("Ops...");
                $('#corpo').html("Parece que houve um problema com algum campo preenchido. Verifique se os dados foram preenchidos corretamente.");

                usuario.paginacao1();
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $('#Erro').modal('show');
            $('#titulo').html("Ops... Ocorreu um erro!");
            $('#corpo').html("Tente novamente.");

        }
    });
}
function IsEmail(email) {
    var exclude = /[^@@-.w]|^[_@@.-]|[._-]{2}|[@@.]{2}|(@@)[^@@]*1/;
    var check = /@@[w-]+./;
    var checkend = /.[a-zA-Z]{2,3}$/;
    if (((email.search(exclude) != -1) || (email.search(check)) == -1) || (email.search(checkend) == -1)) { return false; }
    else { return true; }
}
function validaNome() {
    var nome = $("#nome").val();
    if ((nome == "") || (nome.length < 4)) {
        $("#nome").focus();
        $("#nome").addClass("is-invalid");
        if ($("#nome").hasClass("is-valid"))
            $("#nome").removeClass("is-valid");
        return true;
    }
    else {
        $("#nome").focus();
        $("#nome").addClass("is-valid");
        if ($("#nome").hasClass("is-invalid"))
            $("#nome").removeClass("is-invalid");
        return false;
    }
}
function validaEmail() {
    var email = $("#email").val();
    if (email.includes("@")) {
        $("#email").focus();
        $("#email").addClass("is-valid");
        if ($("#email").hasClass("is-invalid"))
            $("#email").removeClass("is-invalid");
        return false
    }
    else {
        $("#email").focus();
        $("#email").addClass("is-invalid");
        if ($("#email").hasClass("is-valid"))
            $("#email").removeClass("is-valid");
        return true;
    }
}
function validaData() {
    var dataNascimento = $("#data_nascimento").val();

    var dataNascimento = dataNascimento.split("-");
    var data = new Date(dataNascimento[0], dataNascimento[1] - 1, dataNascimento[2]);
    if ((data <= new Date) || (dataNascimento == "")) {

        $("#data_nascimento").focus();
        $("#data_nascimento").addClass("is-valid");
        if ($("#data_nascimento").hasClass("is-invalid"))
            $("#data_nascimento").removeClass("is-invalid");
        return false
    }
    else {
        $("#data_nascimento").focus();
        $("#data_nascimento").addClass("is-invalid");
        if ($("#data_nascimento").hasClass("is-valid"))
            $("#data_nascimento").removeClass("is-valid");
        return true;
    }
}
function validaTelefone() {
    var telefone = $("#telefone").val();
    if ((telefone == "") || (telefone.length < 14)) {
        $("#telefone").focus();
        $("#telefone").addClass("is-invalid");
        if ($("#telefone").hasClass("is-valid"))
            $("#telefone").removeClass("is-valid");
        return true;
    }
    else {
        $("#telefone").focus();
        $("#telefone").addClass("is-valid");
        if ($("#telefone").hasClass("is-invalid"))
            $("#telefone").removeClass("is-invalid");
        return false;
    }
}
function validaCep() {
    var cep = $("#cep").val();
    if ((cep == "") || (cep.length < 10)) {
        $("#cep").focus();
        $("#cep").addClass("is-invalid");
        if ($("#cep").hasClass("is-valid"))
            $("#cep").removeClass("is-valid");
        return true;
    }
    else {
        $("#cep").focus();
        $("#cep").addClass("is-valid");
        if ($("#cep").hasClass("is-invalid"))
            $("#cep").removeClass("is-invalid");
        return false;
    }
}
function validaCidade() {
    var cidade = $("#cidade").val();
    if ((cidade == "") || (cidade.length < 4)) {
        $("#cidade").focus();
        $("#cidade").addClass("is-invalid");
        if ($("#cidade").hasClass("is-valid"))
            $("#cidade").removeClass("is-valid");
        return false;
    }
    else {
        $("#cidade").focus();
        $("#cidade").addClass("is-valid");
        if ($("#cidade").hasClass("is-invalid"))
            $("#cidade").removeClass("is-invalid");
        return true;
    }
}
function validaBairro() {
    var bairro = $("#bairro").val();
    if ((bairro == "") || (bairro.length < 4)) {
        $("#bairro").focus();
        $("#bairro").addClass("is-invalid");
        if ($("#bairro").hasClass("is-valid"))
            $("#bairro").removeClass("is-valid");
        return false;
    }
    else {
        $("#bairro").focus();
        $("#bairro").addClass("is-valid");
        if ($("#bairro").hasClass("is-invalid"))
            $("#bairro").removeClass("is-invalid");
        return true;
    }
}
function validaRua() {
    var rua = $("#rua").val();
    if ((rua == "") || (rua.length < 4)) {
        $("#rua").focus();
        $("#rua").addClass("is-invalid");
        if ($("#rua").hasClass("is-valid"))
            $("#rua").removeClass("is-valid");
        return false;
    }
    else {
        $("#rua").focus();
        $("#rua").addClass("is-valid");
        if ($("#rua").hasClass("is-invalid"))
            $("#rua").removeClass("is-invalid");
        return true;
    }
}
function validaNumero() {
    var numero = $("#numero").val();
    if ((numero == "")) {
        $("#numero").focus();
        $("#numero").addClass("is-invalid");
        if ($("#numero").hasClass("is-valid"))
            $("#numero").removeClass("is-valid");
        return false;
    }
    else {
        $("#numero").focus();
        $("#numero").addClass("is-valid");
        if ($("#numero").hasClass("is-invalid"))
            $("#numero").removeClass("is-invalid");
        return true;
    }
}
function somenteNumeros(num) {
    var er = /[^0-9.]/;
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}
document.addEventListener("DOMContentLoaded", function () {
    var cpf = $("#cpf").val();
    if (cpf.length == 14) {
        mCPF(cpf);
    }

});
var usuario = {
    buscarCep: function (cep) {
        cep = cep.replace(/[^\d]+/g, '');
        $.getJSON("https://viacep.com.br/ws/" + cep + "/json/", function (data) {
            if (!("erro" in data)) {
                document.getElementById("cidade").value = data.localidade;
                document.getElementById("rua").value = data.logradouro;
                document.getElementById("bairro").value = data.bairro;
                if ($("#cep").hasClass("is-invalid")) {
                    $('#cep').removeClass('is-invalid');
                }
                $("#cep").addClass('is-valid');
            }
            else {
                var div = $("#cep");
                if ($("#cep").hasClass("is-valid")) {
                    $('#cep').removeClass('is-valid');
                }
                $("#cep").addClass('is-invalid');
            }
        });

    },
    paginacao1: function () {
        $('#1').addClass('active');
        if ($("#pag1").hasClass("d-none")) {
            $('#pag1').removeClass('d-none');
            $('#pag1').addClass('d-block');
        }
        if ($("#pag2").hasClass("d-block")) {
            $('#pag2').removeClass('d-block');
            $('#pag2').addClass('d-none');
        }
        if ($("#finalizar").hasClass("d-block")) {
            $('#finalizar').removeClass('d-block');
            $('#finalizar').addClass('d-none');
        }
    },
    paginacao2: function () {
        var cpf = $("#cpf").val();

        if (validarCPF(cpf)) {
            if ($("#cpf").hasClass("is-invalid")) {
                $('#cpf').removeClass('is-invalid');
            }
            $("#cpf").addClass('is-valid');
        }
        else {
            if ($("#cpf").hasClass("is-valid")) {
                $('#cpf').removeClass('is-valid');
            }
            $("#cpf").addClass('is-invalid');
        }
        var valida = true;
        if ($("#cpf").hasClass("is-valid")) {
            if (validaNome()) {
                valida = false
            }
            if (validaEmail()) {
                valida = false
            }
            else if (validaData()) {
                valida = false
            }
            else if (validaTelefone()) {
                valida = false
            }
            else if (valida) {
                $('#2').addClass('active');
                if ($("#pag2").hasClass("d-none")) {
                    $('#pag2').removeClass('d-none');
                    $('#pag2').addClass('d-block');
                }
                if ($("#pag1").hasClass("d-block")) {
                    $('#pag1').removeClass('d-block');
                    $('#pag1').addClass('d-none');
                }
                if ($("#pag3").hasClass("d-block")) {
                    $('#pag3').removeClass('d-block');
                    $('#pag3').addClass('d-none');
                }
            }
            else {
                return
            }

        }

    },
    paginacao3: function () {
        var cep = $("#cep").val();
        usuario.buscarCep(cep);
        var valida = true;
        if ($("#cep").hasClass("is-valid")) {
            if (!validaCidade()) {
                valida = false;
            }
            if (!validaRua()) {
                valida = false;
            }
            if (!validaBairro()) {
                valida = false;
            }
            if (!validaNumero()) {
                valida = false;
            }

            if (valida) {
                if ($("#pag3").hasClass("d-none")) {
                    $('#pag3').removeClass('d-none');
                    $('#pag3').addClass('d-block');
                }
                if ($("#pag2").hasClass("d-block")) {
                    $('#pag2').removeClass('d-block');
                    $('#pag2').addClass('d-none');
                }
            }
            else {
                return
            }
        }
    },
    finalizar: function () {

        if ($("#finalizar").hasClass("d-none")) {
            $('#finalizar').removeClass('d-none');
            $('#finalizar').addClass('d-block');
        }
        if ($("#pag3").hasClass("d-block")) {
            $('#pag3').removeClass('d-block');
            $('#pag3').addClass('d-none');
        }
        var form = {
            cpf: $("#cpf").val(),
            nome: $("#nome").val(),
            email: $("#email").val(),
            dataNascimento: $("#data_nascimento").val(),
            telefone: $("#telefone").val(),
            cep: $("#cep").val(),
            cidade: $("#cidade").val(),
            bairro: $("#bairro").val(),
            rua: $("#rua").val(),
            numero: $("#numero").val(),
            complemento: $("#complemento").val(),
            socio: $("#socio :selected").text(),
            jogador: $("#jogador :selected").text(),
            observacoes: $("#observacao").val(),
            isento: $("#isento").is(':checked'),
        };


        $("#cpfConfirma").html(form.cpf);
        $("#nomeConfirma").html(form.nome);
        $("#emailConfirma").html(form.email);
        dataNascimento = FormatarDataInglesParaPadrao(form.dataNascimento);
        $("#telefoneConfirma").html(form.telefone);
        $("#dataNascimentoConfirma").html(dataNascimento);
        $("#cepConfirma").html(form.cep);
        $("#cidadeConfirma").html(form.cidade);
        $("#bairroConfirma").html(form.bairro);
        $("#ruaConfirma").html(form.rua);
        $("#numeroConfirma").html(form.numero);
        $("#complementoConfirma").html(form.complemento);
        $("#socioConfirma").html(form.socio);
        $("#jogadorConfirma").html(form.jogador);

        $("#observacaoConfirma").html(form.observacoes);
        if (form.isento == 1) {
            form.isento = "Isento.";
        }
        else {
            form.isento = "Não isento.";
        }
        $("#isentoConfirma").html(form.isento);


    }
};