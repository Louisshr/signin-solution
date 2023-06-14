function validateUsername(username) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(username);
    if (!ok) {
        $("#invalidUsername").html("username must consist of between 2-20 letters");
        return false;
    }
    else {
        $("#invalidUsername").html("");
        return true;
    }
}

function validatePassword(password) {
    const regexp = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/;
    const ok = regexp.test(password);
    if (!ok) {
        $("#invalidPassword").html("password must consist of at least 6 signs, of which one is a letter and another a number");
        return false;
    }
    else {
        $("#invalidPassword").html("");
        return true;
    }
}
