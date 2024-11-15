document.addEventListener("DOMContentLoaded", function() {
    async function getUserProfile() {
    var token = localStorage.getItem("token")

      try {
        const response = await fetch('https://localhost:7016/api/Usuario',{ method: 'GET',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin':'*',
                'Authorization' : "Bearer " + token
            }),}); 
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
        
        const data = await response.json();
        
        document.getElementById('username').textContent = data.userName;
        document.getElementById('nombre').textContent = data.nombre;
        document.getElementById('apellido').textContent = data.apellido;
        document.getElementById('habitacion').textContent = data.nroHabitacion;
        document.getElementById('zona').textContent = data.zonaHab;
        document.getElementById('estado').textContent = data.estadoUser;
        document.getElementById('fechaInicio').textContent = data.fech_abordo.substring(0,10);
        document.getElementById('fechaFin').textContent = data.fech_desbordo.substring(0,10);
      } catch (error) {
        console.error('Error:', error);
        alert('No se pudo cargar la información del perfil.');
      }
    }
  
    getUserProfile();
    document.getElementById("savePasswordBtn").addEventListener("click", async function() {
      const newPassword = document.getElementById("newPassword").value;
      const confirmNewPassword = document.getElementById("confirmNewPassword").value;
      console.log('asdasd')
     
      if (newPassword !== confirmNewPassword) {
          alert("La nueva contraseña y su confirmación no coinciden.");
          return;
      }

      var token = localStorage.getItem("token");

      try {
          const validateResponse = await fetch('https://localhost:7016/api/Usuario?contraseña='+ newPassword, {
              method: 'put',
              headers: {
                  'Content-Type': 'application/json',
                  'Authorization': 'Bearer ' + token
              },
          });

          if (!validateResponse.ok) {
              alert("La contraseña actual es incorrecta.");
              return;
          }

          

          if (validateResponse.ok) {
              alert("Contraseña actualizada correctamente.");
              document.getElementById("changePasswordForm").reset();
              new bootstrap.Modal(document.getElementById("changePasswordModal")).hide();
          } else {
              alert("Hubo un error al actualizar la contraseña.");
          }
      } catch (error) {
          console.error("Error:", error);
          alert("Error al procesar la solicitud.");
      }
  });
    document.addEventListener("DOMContentLoaded", function() {
      async function getUserProfile() {
      }
  
      getUserProfile();
  
      
  });
  

  });
  