function validaNome() {
    var nome = $("#nome").val();
    if ((nome != "") && (nome.length > 3)) {
        $("#nome").focus();
        $("#nome").addClass("is-valid");
        if ($("#nome").hasClass("is-invalid"))
            $("#nome").removeClass("is-invalid");
        return true;
    }
    else {
        $("#nome").focus();
        $("#nome").addClass("is-invalid");
        if ($("#nome").hasClass("is-valid"))
            $("#nome").removeClass("is-valid");
        
        return false;
    }
}
function FormatarDataPadraoParaIngles(date) {
    var data = date.split("/");
    var dia = data[0];
    var mes = data[1];
    var ano = data[2];

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
function formatarMoeda() {
    var elemento = document.getElementById('valor');
    var valor = elemento.value;

    valor = valor + '';
    valor = parseInt(valor.replace(/[\D]+/g, ''));
    valor = valor + '';
    valor = valor.replace(/([0-9]{2})$/g, ",$1");

    if (valor.length > 6) {
        valor = valor.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
    }
    elemento.value = valor;
    if (valor == "NaN" || valor == 0) {
        $("#valor").focus();
        $("#valor").addClass("is-invalid");
        if ($("#valor").hasClass("is-valid"))
            $("#valor").removeClass("is-valid");
        return false;
    }
    else {
        $("#valor").focus();
        $("#valor").addClass("is-valid");
        if ($("#valor").hasClass("is-invalid"))
            $("#valor").removeClass("is-invalid");
        return true;
    }
}
function validaData() {
    var dataVencimento = $("#data-vencimento").val();

    var dataVencimento = dataVencimento.split("-");
    var data = new Date(dataVencimento[0], dataVencimento[1] - 1, dataVencimento[2]);
    if (data < new Date) {
        $("#data-vencimento").focus();
        $("#data-vencimento").addClass("is-invalid");
        if ($("#data-vencimento").hasClass("is-valid"))
            $("#data-vencimento").removeClass("is-valid");

        return false
    }
    else {
        $("#data-vencimento").focus();
        $("#data-vencimento").addClass("is-valid");
        if ($("#data-vencimento").hasClass("is-invalid"))
            $("#data-vencimento").removeClass("is-invalid");
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
    if (num.value == "") {
        $("#numero").focus();
        $("#numero").addClass("is-invalid");
        if ($("#numero").hasClass("is-valid"))
            $("#numero").removeClass("is-valid");
        return false;
    }
    if (num.value == 0) {
        $("#numero").focus();
        $("#numero").addClass("is-invalid");
        if ($("#numero").hasClass("is-valid"))
            $("#numero").removeClass("is-valid");
        return false;
    }
    if (isNaN(num.value)) {
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
function Limpar() {

    $("#id").val("");
    $("#id").removeClass("is-invalid");
    $("#id").removeClass("is-valid");

    $("#nome").val("");
    $("#nome").removeClass("is-invalid");
    $("#nome").removeClass("is-valid");

    $("#data-vencimento").val("");
    $("#data-vencimento").removeClass("is-invalid");
    $("#data-vencimento").removeClass("is-valid");

    $("#valor").val("");
    $("#valor").removeClass("is-invalid");
    $("#valor").removeClass("is-valid");

    $("#numero").val("");
    $("#numero").removeClass("is-invalid");
    $("#numero").removeClass("is-valid");

}
function Finalizar() {
    var valida = true;
    if (validaNome() == false) {
        valida = false;
    }
    if (validaData() == false) {
        valida = false;
    }
    if (formatarMoeda() == false) {
        valida = false;
    }
    var aux = $("#numero");
    if (somenteNumeros(aux[0]) == false) {
        valida = false;
    }

    if (valida == true) {
        var formData = new FormData();
        var id = $("#id").val();
        if (id == "") {
            id = 0;
        }
        else {
            id = $("#id").val();
        }
        var imagem = $("#imagem");
        formData.append("Id", id);
        formData.append("Nome", $("#nome").val());
        formData.append("Valor", $("#valor").val());
        formData.append("Parcelas", $("#numero").val());
        formData.append("DataVencimento", $("#data-vencimento").val());
        //formData.append("Imagem", imagem.files[1]);
        //formData.append("Descricao", $("descricao").val());
        //formData.append("Alt", $("alt").val());

        $.ajax({
            type: 'POST',
            url: '/Patrocinador/Gravar',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.retorno == 1) {


                    window.location.href = "/Patrocinador/Lista";
                }
                if (response == 99) {
                    $('#Erro').modal('show');
                    $('#titulo').html("Ops...");
                    $('#corpo').html("A duração do contrato deve ser de no mínimo 1 mês.");
                }
                else {
                    $('#Erro').modal('show');
                    $('#titulo').html("Ops...");
                    $('#corpo').html("Parece que houve um problema com algum campo preenchido. Verifique se os dados foram preenchidos corretamente.");


                }
            },
            error: function (error) {
                $('#Erro').modal('show');
                $('#titulo').html("Ops... Ocorreu um erro!");
                $('#corpo').html("Tente novamente.");
            }
        });
    }

}