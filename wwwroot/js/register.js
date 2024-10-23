let contraseña = document.getElementById("contraseña").value;
let contraseña2 = document.getElementById("contraseña2").value;

if (contraseña === contraseña2) {
    if (contraseña.length < 8) {
        alert("La contraseña debe tener al menos 8 caracteres");
    } else if (!/[A-Z]/.test(contraseña)) {
        alert("La contraseña debe contener al menos una letra mayúscula");
    } else if (!/[!@#$%^&*(),.?":{}|<>]/.test(contraseña)) {
        alert("La contraseña debe contener al menos un carácter especial");
    } else {
        alert("Contraseña válida");
        document.getElementById('formRegistro').submit();
    }
} else {
    alert("Las contraseñas no coinciden");
}
