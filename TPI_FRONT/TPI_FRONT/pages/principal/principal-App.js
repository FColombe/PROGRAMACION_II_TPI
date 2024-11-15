
async function obtenerDiaDelViaje() {
  console.log("asdfgh");
  var token = localStorage.getItem("token")
  try {
    const response = await fetch('https://localhost:7016/api/Usuario', {
      method: 'GET',
      headers: new Headers({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Authorization': "Bearer " + token
      })
    });

    if (!response.ok) {
      throw new Error(`Error en la solicitud: ${response.statusText}`);
    }

    const usuarioData = await response.json();
    const fechaInicio = new Date(usuarioData.fech_abordo);
    const fechaFin = new Date(usuarioData.fech_desbordo);
    const hoy = new Date();

    const diferenciaDias = Math.ceil((hoy - fechaInicio) / (1000 * 60 * 60 * 24));
    console.log(diferenciaDias)
    mostrarDiaDelViaje(diferenciaDias);
    await filtrarActividadesDelDia(); 
  } catch (error) {
    console.error('Error al obtener el día del viaje:', error);
  }
}

function mostrarDiaDelViaje(diaDelViaje) {
  const navbarElemento = document.getElementById('diaViaje');
  if (navbarElemento) {
      if(diaDelViaje < 1) {
          navbarElemento.textContent = `El viaje aun no comenzo`;
      } else if (diaDelViaje > 7) {
          navbarElemento.textContent = `Viaje finalizado`;
      } else {
          navbarElemento.textContent = `día del viaje ${diaDelViaje}`;
      }
  }
}

async function filtrarActividadesDelDia() {
  try {
    const response = await fetch('https://localhost:7016/api/ReservasActividade', {
      method: 'GET',
      headers: new Headers({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Authorization': "Bearer " + localStorage.getItem("token")

      })
    });

    if (!response.ok) {
      throw new Error(`Error al obtener actividades: ${response.statusText}`);
    }

    const actividades = await response.json();
    
    const hoy = new Date();
    const hoyFormato = hoy.toISOString().split('T')[0];
    
    console.log(actividades)
    console.log(hoy)
    const actividadesHoy = actividades.filter(actividad => new Date(actividad.fechaReserva).toISOString().split('T')[0] == hoyFormato);
    mostrarActividades(actividadesHoy);
  } catch (error) {
    console.error('Error al obtener actividades:', error);
  }
}

function mostrarActividades(actividades) {
  const listaActividades = document.getElementById('listaActividades');
  listaActividades.innerHTML = ""; 
  
  actividades.forEach(actividad => {
    const listItem = document.createElement('li');
    listItem.textContent = `${actividad.fechaReserva.substring(11, 16)} - ${actividad.nombreActividad}`;
    listaActividades.appendChild(listItem);
  });
}

document.addEventListener("DOMContentLoaded", obtenerDiaDelViaje);
