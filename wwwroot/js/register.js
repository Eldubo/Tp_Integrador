function validarContrasenia(){
    let contrasenia1 = document.getElementById("contraseña").value
    let contrasenia2 = document.getElementById("contraseña2").value
    if(contrasenia1 !== contrasenia2){
        alert("Las contrasenias no coinciden")
        return;
    }
    else if(contrasenia1.length < 8){
        alert("La contrasenia debe tener mas de 8 caracteres")
        return;
    }
    else if (!/[A-Z]/.test(contrasenia1)){
        alert("La contrasenia debe tener una letra mayuscula")
        return;
    }
    else if(!/[!@#$%^&*(),.?":{}|<>]/.test(contrasenia1)){
        alert("La contrasenia debe tener un caracter especial (!@#$%^&*(),.?:{}|<></>)")
        return;
    }
    else {
    document.getElementById("registerForm").submit();
    return;
    }
}