export const usuarioAutenticado = () => localStorage.getItem('usuario-login') !== null;

export const parseJwt = () => {
    const jwt = localStorage.getItem('usuario-login')
   if( jwt !== null){
    let base64 = localStorage.getItem('usuario-login').split('.')[1];
    return JSON.parse( window.atob(base64) );
   } else {
    return ""
   }
};