function validarContraseña(){
    let contraseña1 = document.getElementById("contraseña")
    let contraseña2 = document.getElementById("contraseña2")
    if(contraseña1 !== contraseña2){
        alert("Las contraseñas no coinciden")
    }
    else if(contraseña1.length < 8){
        alert("La contraseña debe tener mas de 8 caracteres")
    }
    else if (!/[A-Z]/.test(contraseña1)){
        alert("La contraseña debe tener una letra mayuscula")
    }
    else if(!/[!@#$%^&*(),.?":{}|<>]/.test(contraseña1)){
        alert("La contraseña debe tener un caracter especial (!@#$%^&*(),.?:{}|<></>)")
    }
    else {
    document.getElementById("registerForm").submit();
    }
}