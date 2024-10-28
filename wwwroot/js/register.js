function validarContraseña(){
    let contraseña1 = document.getElementById("contraseña")
    let contraseña2 = document.getElementById("contraseña2")
    if(contraseña1 !== contraseña2){
        alert("Las contraseñas no coinciden")
        return;
    }
    else if(contraseña1.length < 8){
        alert("La contraseña debe tener mas de 8 caracteres")
        return;
    }
    else if (!/[A-Z]/.test(contraseña1)){
        alert("La contraseña debe tener una letra mayuscula")
        return;
    }
    else if(!/[!@#$%^&*(),.?":{}|<>]/.test(contraseña1)){
        alert("La contraseña debe tener un caracter especial (!@#$%^&*(),.?:{}|<></>)")
        return;
    }
    else {
    document.getElementById("registerForm").submit();
    return;
    }
}