export const usuarioAutenticado = () => localStorage.getItem("usuario") !== null;

export const parseJwt = () => {
    var base64url = localStorage.getItem("usuario").split(".")[1]
    var base64 = base64url.replace(/-/g, '+').replace(/_/g, '/')

    return JSON.parse(window.atob(base64))
}