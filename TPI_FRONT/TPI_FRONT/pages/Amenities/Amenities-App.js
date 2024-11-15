const selectCategoria = document.querySelector('#categoriaSelect');
const row_amenities = document.querySelector('#row_amenities');

let amenities = [];


async function responseSelect() {
    await fetch('https://localhost:7016/api/Categoria',{
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin':'*'
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
responseSelect();


function mostrarAmenities(amenitiesFiltradas) {
    row_amenities.innerHTML = ''; // 
    amenitiesFiltradas.forEach(amenity => {
        const cardHTML = `
            <div class="col-md-6 col-lg-6 mb-4">
                <div class="card h-100 shadow-sm amenity-card" data-amenity="${amenity.nombre}">
                    <div class="card-body text-center">
                        <div class="activities-item-rating">
                        </div>
                        
                        <h5 class="card-title">${amenity.nombre}</h5>
                        <p class="card-text">${amenity.descripcion}</p>
                        <p class="activities-item-description">${amenity.idCategoriaNavigation.descripcion}</p>
                    </div>
                </div>
            </div>
        `;
        row_amenities.innerHTML += cardHTML; 
    });
}


async function responsePuntuaciones() {
    await fetch('https://localhost:7016/api/Amenities', {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
        }),
        mode: 'cors'
    }).then((res) => res.json()).then(json => {
        amenities = json; 
        mostrarAmenities(amenities); 
    });
}

responsePuntuaciones();


selectCategoria.addEventListener('change', () => {
    const categoriaSeleccionada = selectCategoria.value;
    console.log('Categoría seleccionada:', categoriaSeleccionada);

   
    const amenitiesFiltradas = categoriaSeleccionada === 'Todas' ?
                               amenities : 
                               amenities.filter(a => a.idCategoria == categoriaSeleccionada);
    mostrarAmenities(amenitiesFiltradas); 
});
