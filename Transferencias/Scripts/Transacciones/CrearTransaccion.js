
$(function () {
    ObtenerClientes();
});

function Enviar() {
    var data = {};
    var inputs = $('#Formulario').serializeArray();
    $.each(inputs, function (i, input) {
        data[input.name] = input.value;
    });

    $.ajax({
        type: 'POST',
        url: 'Home/CrearTransaccion',
        data: data,
        success: function (resultado) {
            console.log(resultado);
        },
        error: function (a, b) {
            console.log("Algo salió mal.");
        }
    });
}

function ObtenerClientes() {
    $.ajax({
        type: 'POST',
        url: 'Home/GetClientes',
        success: function (resultado) {

            $.each(resultado, function (i, dato) {
                $('#ClienteOrigen').append($('<option>', {
                    value: dato.Id,
                    text: dato.Identificacion
                }));

                $('#ClienteDestino').append($('<option>', {
                    value: dato.Id,
                    text: dato.Identificacion
                }));
            });
        },
        error: function (a, b) {
            console.log("Algo salió mal.");
        }
    });
}

$('#ClienteOrigen').on("change", function () {
    ListarCuentas('#OrigenCuenta', '#ClienteOrigen');
});

$('#ClienteDestino').on("change", function () {
    ListarCuentas('#DestinoCuenta', '#ClienteDestino');
});

function ListarCuentas(input, origen) {
    $(input).empty();
    $.ajax({
        type: 'POST',
        url: 'Home/GetCuentas',
        data: { id: Number($(origen).val()) },
        success: function (resultado) {

            $.each(resultado, function (i, dato) {
                $(input).append($('<option>', {
                    value: dato.Id,
                    text: dato.Numero
                }));
            });
        },
        error: function (a, b) {
            console.log("Algo salió mal.");
        }
    });
}