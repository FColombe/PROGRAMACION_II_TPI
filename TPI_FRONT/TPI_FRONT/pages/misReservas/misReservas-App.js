async function obtenerReservas() {
    var token = localStorage.getItem("token");

    try {
        const response = await fetch('https://localhost:7016/api/ReservasActividade', {
            method: 'GET',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + token
            })
        });

        const reservas = await response.json();
        const reservasTableBody = document.getElementById('reservasTableBody');

        reservas.forEach(reserva => {
            
            const fila = document.createElement('tr');
            fila.innerHTML = `
                <td class="pe-4">${reserva.nombreActividad}</td>
                <td>${reserva.fechaReserva.substring(0,10)}</td>
                <td class="pe-4">${reserva.turnoA}</td>
                <td>${reserva.zonaA}</td>
                <td>${reserva.piso}</td>
                <td>${reserva.cantidadReserva}</td>
                <td>$${reserva.costo}</td>
                
                <td><button onclick="cancelarReserva('${reserva.idReservaAct}', '${reserva.fechaReserva}')" class="btn btn2 btn-sm ms-4">Cancelar</button></td>
            `;
            reservasTableBody.appendChild(fila);
        });
    } catch (error) {
        console.error("Error:", error);
    }
}

async function obtenerReservasGastro() {
    var token = localStorage.getItem("token");

    try {
        const response = await fetch('https://localhost:7016/api/ReservasServicios', {
            method: 'GET',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + token
            })
        });

        const reservas2 = await response.json();
        const reservasGastro = document.getElementById('reservasGastro');

        reservas2.forEach(reserva => {
            const fila = document.createElement('tr');
            fila.innerHTML = `
                <td>${reserva.nombreServ}</td>
                <td>${reserva.fecha.substring(0,10)}</td>
                <td>${reserva.cantidad}</td>
                <td><button onclick="cancelarReservaGastro('${reserva.idReservaGastro}', '${reserva.fecha}')" class="btn btn2 btn-sm ms-4">Cancelar</button></td>
            `;
            reservasGastro.appendChild(fila);
        });
    } catch (error) {
        console.error("Error:", error);
    }
}

function cancelarReserva(id, fechaReserva) {
    const fechaActual = new Date();
    const fechaReservaDate = new Date(fechaReserva);
    
    if (fechaReservaDate < fechaActual) {
        alert("No puedes cancelar una reserva de una fecha pasada.");
        return;
    }
    
    const diferenciaHoras = (fechaReservaDate - fechaActual) / (1000 * 60 * 60);
    if (diferenciaHoras <= 24) {
        alert("No puedes cancelar una reserva 24 horas antes del evento.");
        return;
    }

    if (confirm("¿Estás seguro de que deseas cancelar esta reserva?")) {
        fetch(`https://localhost:7016/api/ConsumosHabitacione/${id}`, {
            method: 'DELETE',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + localStorage.getItem("token")
            })
        })
        .then(response => {
            if (response.ok) {
                alert("Reserva cancelada exitosamente.");
                location.reload();
            } else {
                alert("Error al cancelar la reserva.");
            }
        })
        .catch(error => console.error("Error:", error));
    }
}

function cancelarReservaGastro(id, fechaReserva) {
    const fechaActual = new Date();
    const fechaReservaDate = new Date(fechaReserva);

    if (fechaReservaDate < fechaActual) {
        alert("No puedes cancelar una reserva de una fecha pasada.");
        return;
    }

    const diferenciaHoras = (fechaReservaDate - fechaActual) / (1000 * 60 * 60);
    if (diferenciaHoras <= 24) {
        alert("No puedes cancelar una reserva 24 horas antes del evento.");
        return;
    }

    if (confirm("¿Estás seguro de que deseas cancelar esta reserva gastronómica?")) {
        fetch(`https://localhost:7016/api/ReservasServicios/${id}`, {
            method: 'DELETE',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + localStorage.getItem("token")
            })
        })
        .then(response => {
            if (response.ok) {
                alert("Reserva gastronómica cancelada exitosamente.");
                location.reload();
            } else {
                alert("Error al cancelar la reserva gastronómica.");
            }
        })
        .catch(error => console.error("Error:", error));
    }
}

document.addEventListener('DOMContentLoaded', obtenerReservas);
document.addEventListener('DOMContentLoaded', obtenerReservasGastro);
