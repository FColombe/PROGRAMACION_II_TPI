// Elementos del DOM
const selectCategoria = document.querySelector('#categoriaSelect');
const row_rating = document.querySelector('#row_rating');
const token = localStorage.getItem("token");
let actividadId =0;
let actividades = []
let costo = 0;
async function responseSelect() {
    try {
        const res = await fetch('https://localhost:7016/api/Categoria', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            },
            mode: 'cors'
        });
        const json = await res.json();
        json.forEach(item => {
            let option = document.createElement('option');
            option.value = item.descripcion;
            option.innerHTML = item.descripcion;
            selectCategoria.appendChild(option);
        });
    } catch (error) {
        console.error("Error al cargar las categorías:", error);
    }
}


async function responseSelect() {
    var token = localStorage.getItem("token")
    console.log(token)
    await fetch('https://localhost:7016/api/Categoria',{
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin':'*',
            'Authorization' : "Bearer " + token
        }),
        mode:'cors'
    }).then((res)=> res.json()).then(json => {

        const allOption = document.createElement('option');
        allOption.value = 'Todas';
        allOption.innerHTML = 'Todas';
        selectCategoria.appendChild(allOption);
        for(let i = 0; i < json.length; i++){
            let option = document.createElement('option')
            option.value = json[i].idCategoria
            option.innerHTML = json[i].descripcion
            selectCategoria.appendChild(option)
        }
    })
}

selectCategoria.addEventListener('change', () => {
    const tipoSeleccionado = selectCategoria.value;
    console.log(tipoSeleccionado)
    const actividadesFiltradas = tipoSeleccionado == 'Todas' ? 
                               actividades : 
                               actividades.filter(s => s.idCategoria == tipoSeleccionado);
    mostrarActividades(actividadesFiltradas);
    console.log(actividadesFiltradas)

});



function mostrarActividades (act){
    row_rating.innerHTML = " "
    act.forEach(activity => {
        const cardHTML = `
            <div class="col-md-6 col-lg-6 mt-5">
                <div class="card me-5 h-100 shadow-sm amenity-card">
                    <div class="card-body text-center">
                        <h5 class="card-title">${activity.nombre}</h5>
                        <p class="card-text w-75 mt-4">${activity.descripcion}</p>
                        <p class="card-text w-75 "><span class = "bol">Código de vestimenta:</span> ${activity.idCodVestimentaNavigation.descripcion}</p>
                        <p class="card-text w-75 "><span class = "bol">Destinatarios:</span> ${activity.idDestinatarioNavigation.descripcion}</p>
                        <p class="card-text w-75 "><span class = "bol">Zona:</span> ${activity.idZonaNavigation.descripcion} - <span class = "bol">Piso:</span> ${activity.idZonaNavigation.piso} </p>
                        <div class="text-center mt-3">
                            <p class="activities-item-price">$${activity.costo.toFixed(2)}</p>
                            <p class="activities-item-price">${activity.cupoMax == 0 ? 'Sin Cupos Disponibles' : 'Cupos disponibles: '+activity.cupoMax}</p>
                        </div>
                    </div>
                    <div class="card-footer d-flex justify-content-center align-items-center">
                        <button class="btn btn2 w-50 mt-2 mb-2" costo="${activity.costo}" id="${activity.idActividad}" ${activity.cupoMax <= 0 ?'disabled':''}> ${activity.cupoMax <= 0 ?'No disponible':'Reservar ahora'}</button>
                    </div>
                </div>
            </div>
        `;
        row_rating.innerHTML += cardHTML;
    });

}

async function responsePuntuaciones() {
    try {
        const res = await fetch('https://localhost:7016/api/Actividade', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            },
            mode: 'cors'
        });
        const json = await res.json();
        actividades = json
        mostrarActividades(actividades)
        document.querySelectorAll('.btn2').forEach(button => {
            button.addEventListener('click', openReservaModal);
        });
    } catch (error) {
        console.error("Error al cargar las actividades:", error);
    }
}


function openReservaModal(event) {
    event.preventDefault();
    const actId = event.target.getAttribute('id');
    const precio = event.target.getAttribute('costo');
    const act =actividades.find(e => e.idActividad == parseInt(actId))
    if(act !=null && act.cupoMax <= 0){
        alert("Sin cupo Disponible")
return;
    }

    actividadId = actId;
    costo = parseInt(precio);

    const reservaModal = new bootstrap.Modal(document.getElementById('modalReserva'));
    reservaModal.show();
}

document.getElementById('confirmarReserva').addEventListener('click', async () => {
    // const actividadId = parseInt(document.getElementById('actividadId').value);
    const fechaReserva = document.getElementById('fechaReserva').value;
    const horaReserva = document.getElementById('horaReserva').value;
    const personas = document.getElementById('personas').value;
    const datetime = `${fechaReserva}T${horaReserva}:00.000`;
    try {
        const response = await fetch('https://localhost:7016/api/ConsumosHabitacione', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            },
            body: JSON.stringify({
                nroHabitacion: 0,
                idUsuario: 0,
                fecha: new Date().toISOString(),
                consumosGastronomicos:null,
                reservasActividades: [
                    {
                        idActividad: actividadId,
                        fechaReservada: datetime,
                        cantidadReservada: personas,
                        costoUnitario: costo
                    }
                ]
            })
        });

        if (response.ok) {
            alert('Reserva confirmada');
        } else {
            alert('Error al reservar');
        }
    } catch (error) {
        console.error("Error al realizar la reserva:", error);
    }
});

document.addEventListener("DOMContentLoaded", () => {
    responseSelect();
    responsePuntuaciones();
});
