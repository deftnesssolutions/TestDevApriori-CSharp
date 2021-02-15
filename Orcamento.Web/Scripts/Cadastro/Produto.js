function set_dados_form(dados) {
    $('#id_cadastro').val(dados.Id);
    $('#txt_nome').val(dados.Nome);
    $('#txt_preco').val(dados.Preco);  
}

function set_focus_form() {
    var alterando = (parseInt($('#id_cadastro').val()) > 0)
    $('#txt_nome').focus();
}

function get_dados_inclusao() {
    return {
        Id: 0,
        Nome: '',
        Preco: 0,
    };
}

function get_dados_form() {
    var form = new FormData();
    form.append('Id', $('#id_cadastro').val());
    form.append('Nome', $('#txt_nome').val());
    form.append('Preco', $('#txt_preco').val());
    return form;
}

function preencher_linha_grid(param, linha) {
    linha
        .eq(0).html(param.Nome).end()
        .eq(1).html(param.Preco).end()
}

function salvar_customizado(url, param, salvar_ok, salvar_erro) {
    $.ajax({
        type: 'POST',
        processData: false,
        contentType: false,
        data: param,
        url: url,
        dataType: 'json',
        success: function (response) {
            salvar_ok(response, get_param());
        },
        error: function () {
            salvar_erro();
        }
    });
}

function get_param() {
    return {
        Id: $('#id_cadastro').val(),
        Nome: $('#txt_nome').val(),
        Preco: $('#txt_preco').val(),
    };
}

$(document)
.ready(function () {
    $('#txt_preco,#txt_preco').mask('#.##0,00', { reverse: true });
})
