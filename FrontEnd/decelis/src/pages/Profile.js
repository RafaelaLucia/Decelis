import { React, useState, useEffect } from "react";
import "../styles/Profile.css";
import NavBar from "../components/NavBar";
import Form from "react-bootstrap/Form";
import { parseJwt } from "../services/auth";
import api from "../services/api";

export default function Profile() {
  const [listProfile, setListProfile] = useState([]);
  const [idUser, setIdUser] = useState("");
  const [name, setName] = useState("");
  const [userImage, setUserImage] = useState("");
  const [imagePreview, setImagePreview] = useState("");
  const [email, setEmail] = useState("");
  const [status, setStatus] = useState("");
  const [level, setLevel] = useState("");
  const [type, setType] = useState("");
  const [password, setPassword] = useState("");

  const handleClass = (idClass) => {
    if (idClass == 1) {
      return "Básico";
    } else if (idClass == 2) {
      return "Intermediário";
    } else if (idClass == 2) {
      return "Avançado";
    } else if (idClass == 4) {
      return "Baby";
    }
  };

  function searchProfile() {
    api("/UserInfos/" + parseJwt().jti, {
      headers: {
        Authorization: "Bearer " + localStorage.getItem("usuario-login"),
      },
    })
      .then((response) => {
        if (response.status === 200) {
          setListProfile(response.data);
          setIdUser(response.data.idUser);
    setUserImage(response.data.userImage);
    setName(response.data.nameUser);
    setEmail(response.data.email);
    setStatus(response.data.idStatus);
    setLevel(response.data.idClass);
    setType(response.data.idUserType);
         


          setIdUser(response.data.idUser);
          setUserImage(
            "https://decelis.herokuapp.com/img/" + response.data.userImage
          );
        }
      })
      .catch((error) => console.error(error));
  }


  const editProfile = (e) => {
    e.preventDefault();
    console.log(e.target.value)
   

    var formdata = new FormData();
formdata.append("idUserType", type);
formdata.append("idStatus", status);
formdata.append("idClass", level);
formdata.append("nameUser", name);
formdata.append("email", email);
formdata.append("passwordUser", password);
formdata.append("arquivo", userImage);
formdata.append("idUser", idUser);

var requestOptions = {
  method: 'PUT',
  body: formdata,
};

fetch("https://decelis.herokuapp.com/api/CadastroUsuario?id=" + idUser, requestOptions)


   
      .then((response) => {
        if (response.status !== 404) {
          alert("Usuário Atualizado");

          searchProfile ();
        }
      })
      .catch((erro) => console.log(erro));
  }



  useEffect(searchProfile, []);

  return (
    <div>
      <NavBar />
      <div className="header">
        <h2 className="title-profile">{name}</h2>
        <h2 className="title-profile">Turma: {handleClass(level)}</h2>

        <img className="imageProfile" src={userImage} alt="Imagem do usuário" />
      </div>
      <div className="infos-profile">
        <form id="formProfile" onSubmit={(e) => Save(e)}>
          <Form.Group onChange={(e) => setUserImage(e.target.files[0])} className="imgUpload">
            <Form.Label>Imagem</Form.Label>
            <Form.Control type="file" id="arquivo" />
          </Form.Group>

          <div className="form-group">
            <label htmlFor="email">Nome</label>
            <input
              type="text"
              className="form-control"
              value={name}
              onChange={(e) => {
                setName(e.target.value);
              }}
              id="nameUser"
              autoComplete="off"
              placeholder="Seu nome"
            />
          </div>

          <div className="form-group">
            <label htmlFor="email">E-mail</label>
            <input
              type="text"
              className="form-control"
              value={email}
              onChange={(e) => {
                setEmail(e.target.value);
              }}
              autoComplete="off"
              id="email"
              placeholder="Seu e-mail"
            />
          </div>

          <div className="form-group">
            <label htmlFor="email">Alterar senha</label>
            <input
              type="password"
              className="form-control"
              onChange={(e) => {
                setPassword(e.target.value);
              }}
              autoComplete="off"
              id="email"
              placeholder="Sua nova senha"
            />
          </div>
          <div id="buttonSave">
            <button
              type="button"
              className="btn btn-warning"
              onClick={(e) => editProfile(e)}
            >
              {"Salvar"}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
