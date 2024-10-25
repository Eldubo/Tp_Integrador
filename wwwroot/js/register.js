function validarFormulario() {
    let contraseña = document.getElementById("contraseña").value;
    let contraseña2 = document.getElementById("contraseña2").value;

    if (contraseña !== contraseña2) {
        alert("Las contraseñas no coinciden");
        return false;
    }
    if (contraseña.length < 8) {
        alert("La contraseña debe tener al menos 8 caracteres");
        return false;
    }
    if (!/[A-Z]/.test(contraseña)) {
        alert("La contraseña debe contener al menos una letra mayúscula");
        return false;
    }
    if (!/[!@#$%^&*(),.?":{}|<>]/.test(contraseña)) {
        alert("La contraseña debe contener al menos un carácter especial");
        return false;
    }

    
    alert("Contraseña válida");
    document.getElementById('registerForm').submit();
}
