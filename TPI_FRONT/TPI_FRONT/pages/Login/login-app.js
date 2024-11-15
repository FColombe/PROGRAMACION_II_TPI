console.log('2')
document.getElementById('login').addEventListener('submit', async (event) => {
    event.preventDefault();

    const username = document.getElementById('usuario').value;
    const password = document.getElementById('password').value;

    try {
        const response = await fetch('https://localhost:7016/api/Auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username, password })
        });
        console.log(response)
        if (response.ok) {
            const data = await response.json();
            console.log(data)
            localStorage.setItem('token', data.token);  // Guardamos el token en localStorage
            window.location.href = "../principal/principal.html"
        } else {
            alert('Credenciales incorrectas');
        }
    } catch (error) {
        console.error('Error:', error);
    }
});
