async function obtenerConsumos() {
    var token = localStorage.getItem("token");
    let totalConsumo = 0; 

    try {
        
        const response = await fetch('https://localhost:7016/api/ConsumosHabitacione', {
            method: 'GET',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + token
            })

        });

        const consumos = await response.json();

        const consumosContainer = document.getElementById('consumosContainer');
        consumosContainer.innerHTML = ''; 

        consumos.forEach(consumo => {
            const arrayConsumoGastro = consumo.consumoGastro;
        
            // Si hay productos en consumoGastro, los mostramos
            if (arrayConsumoGastro && arrayConsumoGastro.length > 0) {
                let totalGastro = 0; 
        
                const tarjetaConsumoGastro = document.createElement('div');
                tarjetaConsumoGastro.classList.add('card', 'mb-3');
                tarjetaConsumoGastro.style.maxWidth = '18rem';
                tarjetaConsumoGastro.innerHTML = `
                    <div class="card-body">
                        <h5 class="card-title">Nº consumo: ${consumo.idConsumo}</h5>
                        <h6 class="card-subtitle mb-1 mt-3">Detalle del consumo:</h6>
                    </div>
                `;
        
                arrayConsumoGastro.forEach((producto) => {
                    totalGastro += producto.cantidad * producto.precio; 
                    const productoHTML = `
                        <p class="card-text"><strong>Pedido:</strong> ${producto.nombreProducto}</p>
                        <p class="card-text"><strong>Cantidad:</strong> ${producto.cantidad}</p>
                        <p class="card-text"><strong>Precio Unitario:</strong> $${producto.precio}</p>
                        <p class="card-text"><strong>Costo unitario:</strong> $${producto.cantidad * producto.precio}</p>
                        <hr>
                    `;
                    tarjetaConsumoGastro.innerHTML += productoHTML;
                });
        
            
                tarjetaConsumoGastro.innerHTML += `
                    <div class="text-center mt-3">
                        <button class="btn btn-primary btn-sm total"><strong>Total:</strong> $${totalGastro}</button>
                    </div>
                `;
        
           
                consumosContainer.appendChild(tarjetaConsumoGastro);
            }
            
            // Si no hay productos pero hay una actividad, mostramos la actividad
            else if (consumo.idActividad !== null) {
                const costoReserva = consumo.costoUnitario ? consumo.cantidadAct * consumo.costoUnitario : 0;
                const tarjetaActividad = document.createElement('div');
                tarjetaActividad.classList.add('card', 'mb-3');
                tarjetaActividad.style.maxWidth = '18rem'; 
                tarjetaActividad.innerHTML = `
                    <div class="card-body">
                        <h5 class="card-title">Nº consumo: ${consumo.idConsumo}</h5>
                        <p class="card-text"><strong>Fecha:</strong> ${new Date(consumo.fecha).toLocaleDateString()}</p>
                        <h6 class="card-subtitle mb-1 mt-3">Detalle del consumo:</h6>
                        <p class="card-text"><strong>Actividad:</strong> ${consumo.nombre}</p>
                        <p class="card-text"><strong>Fecha de la actividad:</strong> ${new Date(consumo.fechaReserva).toLocaleDateString()}</p>
                        <p class="card-text"><strong>Cantidad:</strong> ${consumo.cantidadAct}</p>
                        <p class="card-text"><strong>Costo Unitario:</strong> $${consumo.costoUnitario || "No especificado"}</p>
                        <div class="text-center mt-3">
                            <button class="btn btn-primary btn-sm total"><strong>Total:</strong> $${costoReserva}</button>
                        </div>
                    </div>
                `;
                
                consumosContainer.appendChild(tarjetaActividad);
            }
        });
        
        
        
        
        

    } catch (error) {
        console.error("Error:", error);
    }
}

async function obtenerTotal() {
    var token = localStorage.getItem("token");


    try {
        
        const response = await fetch('https://localhost:7016/api/ConsumosHabitacione/Total', {
            method: 'GET',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Authorization': "Bearer " + token
            })
        });

        const total = await response.json();
        const to = total.total;
        const totalConsumos = document.getElementById('totalConsumos');
        totalConsumos.innerHTML = ''; 

        const tot = document.createElement('h3');
        tot.innerHTML = `
            Total consumido: $${to}
        `;
        totalConsumos.appendChild(tot);

    } catch (error) {
        console.error("Error:", error);
    }
}


document.addEventListener('DOMContentLoaded', obtenerConsumos);
document.addEventListener('DOMContentLoaded', obtenerTotal);
