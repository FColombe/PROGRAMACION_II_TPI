
const selectCategoria = document.querySelector('#categoriaSelect')
const row_servicios = document.querySelector('#row_servicios')
let servicios = [];

function mostrarServicios(serviciosFiltrados) {
    row_servicios.innerHTML = '';
    serviciosFiltrados.forEach(servicio => {
        const cardHTML = `
            <div class="col-md-6 col-lg-6 mb-5">
                <div class="card h-100 me-5">
                    <div class="card-body text-center">
                        <h5 class="card-title">${servicio.nombre}</h5>
                        <p class="card-text">${servicio.descripcion}</p>
                        <p class="service-price">${servicio.idTematicaNavigation.descripcion}</p>
                        <p class="service-category">${servicio.idTipoServicioNavigation.tipoServicio}</p>
                    </div>
                    <div class="card-footer d-flex justify-content-center align-items-center">
                        <button type="button" class="btn btn-reservar w-50 mt-2 mb-2" id="${servicio.idServicio}">Reservar ahora</button>
                    </div>
                </div>
            </div>
        `;
        row_servicios.innerHTML += cardHTML;
        document.querySelectorAll('.btn-reservar').forEach(button => {
            button.addEventListener('click', openReservaModal);
        });
    });
}

async function obtenerServicios(){
    await fetch('https://localhost:7016/api/ServicioGastronomico',{
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
        }),
        mode: 'cors'
    }).then((res) => res.json()).then(json => {
        servicios = json;
        mostrarServicios(servicios); 
    });
}



async function responseSelect() {
    var token = localStorage.getItem("token")
    await fetch('https://localhost:7016/api/TipoServicio',{
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
            option.value = json[i].idTipoServicio
            option.innerHTML = json[i].tipoServicio
            selectCategoria.appendChild(option)
        }
    })
}



selectCategoria.addEventListener('change', () => {
    const tipoSeleccionado = selectCategoria.value;
    const serviciosFiltrados = tipoSeleccionado == 'Todas' ? 
                               servicios : 
                               servicios.filter(s => s.idTipoServicio == tipoSeleccionado);
    mostrarServicios(serviciosFiltrados);
});

async function loadMenu() {
    try {
        const response = await fetch('https://localhost:7016/api/ProductosGastronomico');
        const productos = await response.json();
        const menuAccordion = document.getElementById('restaurantMenuAccordion');
        
        menuAccordion.innerHTML = '';

        productos.forEach((producto, index) => {
            const productoId = `producto${index + 1}`;
            const itemsHTML = `
                <li class="mb-3 d-flex align-items-center justify-content-between">
                        <input type="checkbox" class="pe-5" id="${producto.idProducto}" name="plato" value="${producto.precio}" data-nombre="${producto.nombre}">                    
                        <label for="${producto.idProducto}" class="me-auto ps-5">
                        <strong>${producto.nombre}</strong>
                        <br>
                        <span class="text-muted">${producto.descripcion}</span>
                    </label>
                    <span class="fw-bold fs-6">$ ${producto.precio}</span>
                </li>
            `;

            const productoHTML = `
                <div class="accordion-item">
                    <h2 class="accordion-header" id="${productoId}Heading">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#${productoId}Menu" aria-expanded="false" aria-controls="${productoId}Menu">
                            ${producto.nombre}
                        </button>
                    </h2>
                    <div id="${productoId}Menu" class="accordion-collapse collapse" aria-labelledby="${productoId}Heading" data-bs-parent="#restaurantMenuAccordion">
                        <div class="accordion-body">
                            <ul class="list-unstyled">
                                ${itemsHTML}
                            </ul>
                        </div>
                    </div>
                </div>
            `;
            menuAccordion.insertAdjacentHTML('beforeend', productoHTML);
        });
       
        console.log("asd1")
        
    } catch (error) {
        console.error('Error al cargar el menú:', error);
    }
}



async function realizarReserva() {
    const fechaReserva = document.getElementById('fechaReservaGastronomica').value;
    const horaReserva = document.getElementById('horaReservaGastronomica').value;
    const personas = document.getElementById('cantidadPersonas').value;
    const datetime = `${fechaReserva}T${horaReserva}:00.000`; 
    let idGenerico = 99;
    const data = {  idServicio: parseInt(reservaId),fecha:datetime,cantidadReservada:parseInt(personas), idUsuario:idGenerico}
  console.log(data)

    try {
        const response = await fetch('https://localhost:7016/api/ReservasServicios', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + localStorage.getItem("token")
            },
            body: JSON.stringify(data)
            
        });

        console.log(response)
        if (response.ok) {
            alert('¡Reserva realizada con éxito!');
            document.getElementById('orderForm').reset();
        } else {
            alert('Error al realizar la reserva. Por favor, inténtalo nuevamente.');
        }
        console.log("asd")
        const modalFooter = document.querySelector('.modal-footer');
        modalFooter.innerHTML += `
            <button type="button" class="btn btn-primary" id="confirmarReserva">Confirmar Reserva</button>
        `;

    } catch (error) {
        console.error('Error al enviar la reserva:', error);
    }
}

document.getElementById('confirmarReservaGastronomica').addEventListener('click', async () => {
    realizarReserva()
});








function openReservaModal(event) {
    event.preventDefault();
    console.log("asd2")
    const reserva = event.target.getAttribute('id');
    reservaId =reserva
   

    const reservaModal = new bootstrap.Modal(document.getElementById('modalReservaGastronomica'));
    reservaModal.show();
}
let reservaId;




//funcion de transcaccion
document.getElementById('confirmarReserva').addEventListener('click', async () => {
    const productosSeleccionados = Array.from(document.querySelectorAll('input[name="plato"]:checked'));
    console.log(productosSeleccionados[0].id)
    listaProductos = []
    productosSeleccionados.forEach( producto => {
        listaProductos.push({idProducto:producto.id, 
                precio: producto.value,
                cantidad: 1
        })
    })
    try {
        const response = await fetch('https://localhost:7016/api/ConsumosHabitacione', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' +  localStorage.getItem("token")
            },
            body: JSON.stringify({
                nroHabitacion: 1,
                idUsuario: 1,
                fecha: new Date().toISOString(),
                reservasActividades: null,
                consumosGastronomicos: listaProductos
            })
        });

        if (response.ok) {
            alert('Pedido confirmado. Pronto estaremos en tu puerta.');
        } else {
            alert('Error al reservar');
        }
    } catch (error) {
        console.error("Error al realizar la reserva:", error);
    }
});


document.addEventListener('DOMContentLoaded', () => {
    obtenerServicios();
    responseSelect();
    loadMenu();
});