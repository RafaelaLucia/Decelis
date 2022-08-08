import React, { useState, useEffect } from "react";
import Menu from "../components/NavBar";
import Form from "react-bootstrap/Form";
import { parseJwt } from "../services/auth";
import Jumbotron from "../components/jumbotron";
import Table from "react-bootstrap/Table";
import "../styles/CreateUser.css";
import url from "../services/api";

export default function CreateUser() {
  const [users, setUsers] = useState([]);
  const [idUser, setIdUser] = useState("");
  const [name, setName] = useState("");
  const [userImage, setUserImage] = useState("");
  const [imagePreview, setImagePreview] = useState("");
  const [email, setEmail] = useState("");
  const [status, setStatus] = useState("");
  const [level, setLevel] = useState("");
  const [type, setType] = useState("");
  const [password, setPassword] = useState("");

  const token = localStorage.getItem("usuario-login");
  useEffect(() => {
    getUsers();
  }, []);

  const handleClass = (idClass) => {
    if (idClass == 1) {
      return "Básico";
    } else if (idClass == 2) {
      return "Intermediário";
    } else if (idClass == 3) {
      return "Avançado";
    } else if (idClass == 4) {
      return "Baby";
    }
  };

  const handleType = (type) => {
    if (type == 1) {
      return "Geral";
    } else if (type == 2) {
      return "Administrador";
    } else {
      return "Root";
    }
  };

  const handleStatus = (status) => {
    if (status == 1) {
      return "Inativo";
    } else if (status == 2) {
      return "Ativo";
    }
  };


  const handleImagePreview = (e) => {
    setImagePreview(URL.createObjectURL(e.target.files[0]));
    console.log(imagePreview);
  };

  const getUsers = (e) => {
    fetch("https://decelis.herokuapp.com/api/Userinfos", {
      method: "GET",
    })
      .then((response) => response.json())
      .then((data) => {
        setUsers(data);
        cancelButton();
      })
      .catch((error) => console.log(error));
  };

  const deleteUser = (e) => {
    url
      .delete("/UserInfos" + "/" + e.target.value, {
        headers: { "Content-Type": "application/json" },
      })
      .then((response) => {
        if (response.status === 204) {
          alert("User removido");
          getUsers();
        }
      })
      .catch((error) => console.error(error));
  };

  const putUser = (e) => {
    setIdUser(e.target.value);
    url
      .get("/UserInfos" + "/" + e.target.value, {
        headers: { "Content-Type": "application/json" },
      })
.then((response) => {
  if (response.status !== 400) {
    setIdUser(response.data.idUser);
    setUserImage(response.data.userImage);
    setName(response.data.nameUser);
    setEmail(response.data.email);
    setStatus(response.data.idStatus);
    setLevel(response.data.idClass);
    setType(response.data.idUserType);
  }
})
.catch((error) => console.error(error));
};



  
  const editUser = (e) => {
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
          cancelButton();
          getUsers();
        }
      })
      .catch((erro) => console.log(erro));
  }



 

  const Save = (e) => {
    e.preventDefault();
    var formdata = new FormData();
    formdata.append("IdUserType", type);
    formdata.append("IdStatus", status);
    formdata.append("IdClass", level);
    formdata.append("NameUser", name);
    formdata.append("Email", email);
    formdata.append("PasswordUser", password);
    formdata.append("arquivo", userImage);

    url
      .post("/CadastroUsuario", formdata, {
        headers: { "content-type": "multipart/form-data" },
      })
      .then((resposta) => {
        if (resposta.status === 201) {
          alert("Usuário Cadastrado");
          cancelButton();
          getUsers();
        }
      })
      .catch((erro) => console.log(erro));
  };

  

  const cancelButton = () => {
    setIdUser("");
    setUserImage("");
    setImagePreview("");
    setName("");
    setEmail("");
    setLevel("");
    setType("");
    setPassword("");
    setStatus("");
  };

  return (
    <div>
      <Menu />
      <Jumbotron titulo="Usuários" descricao="Gerencie seus usuários" />
      <div className="container">
        <div className="bd-example">
          <form id="formFilme" onSubmit={(e) => Save(e)}>
            <div className="form-group">
              <label htmlFor="nome">Nome</label>
              <input
                type="text"
                className="form-control"
                value={name}
                onChange={(e) => {
                  setName(e.target.value);
                }}
                id="nome"
                aria-describedby="nome"
                placeholder="Informe o Nome"
              />
            </div>
            <div className="form-group">
              <Form.Group controlId="formFile" className="mb-3">
                <Form.Label>Imagem de perfil</Form.Label>
                <Form.Control
                  onChange={(e) => {
                    setUserImage(e.target.files[0]), handleImagePreview(e);
                  }}
                  type="file"
                />
                {<img src={imagePreview} style={{ width: "120px" }} />}
              </Form.Group>
            </div>
            <div className="form-group">
              <label htmlFor="email">Email</label>
              <input
                type="text"
                className="form-control"
                value={email}
                onChange={(e) => {
                  setEmail(e.target.value);
                }}
                id="email"
                placeholder="Informe o email"
              />
            </div>
            <div className="form-group">
              <label htmlFor="level">Turma</label>

              <Form.Select
                onChange={(e) => setLevel(e.target.value)}
                value={level}
                aria-label="Informe a turma"
              >
                <option>Informe a turma</option>
                <option value="1">Básico</option>
                <option value="2">Intermediário</option>
                <option value="3">Avançado</option>
                <option value="4">Baby</option>
              </Form.Select>
            </div>
            <div className="form-group">
              <label htmlFor="email">Tipo</label>

              <Form.Select
                onChange={(e) => setType(e.target.value)}
                aria-label="Informe o Tipo"
                value={type}
              >
                <option>Informe o tipo</option>
                <option value="1">Geral</option>
                <option value="2">Administrador</option>
                <option value="3">Root</option>
              </Form.Select>
            </div>
            <div className="form-group">
              <label htmlFor="email">Status</label>

              <Form.Select
                onChange={(e) => setStatus(e.target.value)}
                value={status}
                aria-label="Informe o Status"
              >
                <option>Informe o status</option>
                <option value="1">Inativo</option>
                <option value="2">Ativo</option>
              </Form.Select>
            </div>
            <div className="form-group">
              <label htmlFor="email">Senha</label>
              <input
                className="form-control"
                value={password}
                onChange={(e) => {
                  setPassword(e.target.value);
                }}
                id="senha"
                placeholder="Informe a senha"
              />
            </div>
            <button
              type="button"
              id="form-button"
              onClick={(e) => cancelButton(e)}
              className="btn btn-secondary"
            >
              Cancelar
            </button>
            <button
              type="button"
              id="form-button"
              onClick={(e) => editUser(e)}
              className="btn btn-primary"
            >
              Editar
            </button>
            <button type="submit" id="form-button" className="btn btn-success">
              Salvar
            </button>
          </form>

          <Table responsive>
            <thead>
              <tr>
                <th scope="col">#</th>
                <th scope="col">Imagem</th>
                <th scope="col">Nome</th>
                <th scope="col">Email</th>
                <th scope="col">Turma</th>
                <th scope="col">Tipo</th>
                <th scope="col">Status</th>
                <th scope="col">Senha</th>
                <th scope="col">Ações</th>
                <th scope="col"></th>
              </tr>
            </thead>
            <tbody id="tabela-lista-corpo">
              {users.map((item, key) => {
                return (
                  <tr key={key}>
                    <td>{item.idUser}</td>

                    <td>
                      <img
                        src={
                          "https://decelis.herokuapp.com/img/" + item.userImage
                        }
                        style={{ width: "120px" }}
                      />
                    </td>
                    <td>{item.nameUser}</td>
                    <td>{item.email}</td>
                    <td>{handleClass(item.idClass)}</td>
                    <td>{handleType(item.idUserType)}</td>
                    <td>{handleStatus(item.idStatus)}</td>
                    <td>
                      <p>***</p>
                    </td>

                  
                    <td>
                    {token !== null && parseJwt(token).role === "3" ? (
            <>
             <button
                        type="button"
                        value={item.idUser}
                        onClick={(e) => deleteUser(e)}
                        className="btn btn-danger"
                      >
                        Remover
                      </button>
            </>
          ) : null}
                      <button
                        type="button"
                        value={item.idUser}
                        onClick={(e) => putUser(e)}
                        className="btn btn-warning"
                      >
                        Editar
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </Table>
        </div>
      </div>
    </div>
  );
}
