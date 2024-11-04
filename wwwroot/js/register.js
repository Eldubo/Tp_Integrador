function validarContrasenia() {
    let contrasenia1 = document.getElementById("contraseña").value;
    let contrasenia2 = document.getElementById("contraseña2").value;
    let telefono = document.getElementById("telefono").value;

    if (contrasenia1 !== contrasenia2) {
        alert("Las contraseñas no coinciden");
        return false;
    }
    else if (contrasenia1.length < 8) {
        alert("La contraseña debe tener más de 8 caracteres");
        return false;
    }
    else if (!/[A-Z]/.test(contrasenia1)) {
        alert("La contraseña debe tener una letra mayúscula");
        return false;
    }
    else if (!/[!@#$%^&*(),.?":{}|<>]/.test(contrasenia1)) {
        alert("La contraseña debe tener un carácter especial (!@#$%^&*(),.?:{}|<></>)");
        return false;
    }

    return true;
}
