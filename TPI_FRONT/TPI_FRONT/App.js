const selectCategoria = document.querySelector('#categoriaSelect')
const row_rating = document.querySelector('#row_rating')






async function responseSelect() {
    await fetch('https://localhost:7016/api/Categoria',{
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin':'*',
        }),
        mode:'cors'
    }).then((res)=> res.json()).then(json => {
        for(let i = 0; i < json.length; i++){
            let option = document.createElement('option')
            option.value = json[i].descripcion
            option.innerHTML = json[i].descripcion
            selectCategoria.appendChild(option)
        }
    })
}

responseSelect()

async function responsePuntuaciones(){
    await fetch('https://localhost:7016/api/Actividade',{
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin':'*',
        }),
        mode: 'cors'
    }).then((res)=> res.json()).then(json => {
        console.log(json)
        for(let i = 0; i < json.length; i++){
            const cardHTML = `
                    <div class="col-md-6 col-lg-3 mb-4">
                        <div class="card h-100">
                            /* img */
                            <div class="card-body text-center">
                                <div class="activities-item-rating">
                                    /* puntuacion */
                                </div>
                                <h5 class="card-title">${json[i].nombre}</h5>
                                <p class="card-text">${json[i].descripcion}</p>
                                <p class="activities-item-price">$${json[i].costo.toFixed(2)}</p>
                                <p class="activities-item-description">${json[i].idCategoria} </p>
                            </div>
                            <div class="card-footer bg-white border-top-0">
                                <a href="#" class="btn btn-reservar btn-lg w-100">Reservar ahora</a>
                            </div>
                        </div>
                    </div>
                `;
            row_rating.innerHTML += cardHTML
        }
    })
}

responsePuntuaciones()


/*                                     <span class="stars">${'★'.repeat(json.puntuacion)}${'☆'.repeat(5 - json.puntuacion)}</span>
                                    <span class="rating">${json.puntuacion.toFixed(2)}</span> */
/*  */
