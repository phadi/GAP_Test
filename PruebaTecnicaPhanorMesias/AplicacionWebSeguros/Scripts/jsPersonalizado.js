function mensajePopUp(texto) {
    var modal = document.getElementById("textoModal");
    modal.innerHTML = texto;
    var boton = document.getElementById("btnModal");
    boton.click();
}

function agregaPolizaCliente() {
    var cmbPoliza = document.getElementById("cmbPoliza");
    var cmbCliente = document.getElementById("cmbCliente");
    var txtFecha = document.getElementById("txtFecha");

    var polizaId = cmbPoliza.options[cmbPoliza.selectedIndex].value;
    var poliza = cmbPoliza.options[cmbPoliza.selectedIndex].text;
    var clienteId = cmbCliente.options[cmbCliente.selectedIndex].value;
    var cliente = cmbCliente.options[cmbCliente.selectedIndex].text;
    var fecha = txtFecha.value;

    var msm = "";

    if (clienteId == 0) {
        msm += "Seleccione Cliente" + "<br><br>";
    }

    if (polizaId == 0) {
        msm = "Seleccione Poliza" + "<br><br>" ;
    } 

    if (fecha == "") {
        msm += "Seleccione Fecha";
    }

    if (msm != "") {
        mensajePopUp(msm);
    } else {
        var tbLIstaPolizasCliente = document.getElementById("tbLIstaPolizasCliente");
        var textoCliente = clienteId + ' - ' + cliente
        var textoPoliza = polizaId + ' - ' + poliza
        var iguales = "";

        if (tbLIstaPolizasCliente.rows.length > 1) {
            for (i = 1; i < tbLIstaPolizasCliente.rows.length; i++) {
                var cell = tbLIstaPolizasCliente.rows[i].cells;
                var valCLi = cell[0].innerText;
                var valPol = cell[1].innerText;
                if (textoCliente == valCLi && textoPoliza == valPol) {
                    iguales = "SI"
                    break;
                }
            }
        }

        if (iguales == "") {
            var rowNew = '<td style="vertical-align:middle">' + textoCliente + '</td>' +
                '<td style="vertical-align:middle">' + textoPoliza + '</td>' +
                '<td style="vertical-align:middle">' + fecha + '</td>';
            tbLIstaPolizasCliente.insertRow(-1).innerHTML = rowNew;
        } else {
            mensajePopUp("Ya se encuentra relaciona la Poliza con el Cliente");
        }
        
    }
    
}

function actualizaPolizaCliente() {
    var tbLIstaPolizasCliente = document.getElementById("tbLIstaPolizasCliente");
    var valCLi = [];
    var valPol = [];
    var valFec = [];
    if (tbLIstaPolizasCliente.rows.length > 1) {
        for (i = 1; i < tbLIstaPolizasCliente.rows.length; i++) {
            var cell = tbLIstaPolizasCliente.rows[i].cells;
            valCLi[i - 1] = cell[0].innerText;
            valPol[i - 1] = cell[1].innerText;
            valFec[i - 1] = cell[2].innerText;
        }

        var param = { "clientes": valCLi, "polizas": valPol, "fecha": valFec};
        $.ajax({
            url: '/Cliente/ActualizaListaPolizaCliente',
            type: 'POST',
            data: param,
            success: function (responce) {
                mensajePopUp(responce);
                if (responce == "Registros agregados") {
                    var btnRegresa = document.getElementById("btnRegresa");
                    btnRegresa.click();
                }
                               
            },
            error: function (responce) { mensajePopUp(responce.data); }
        });
    } else {
        mensajePopUp("Agregar relacion Cliente - Poliza");
    }
}