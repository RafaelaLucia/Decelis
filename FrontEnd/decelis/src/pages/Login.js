import React from "react";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { parseJwt } from "../services/auth";
import "../styles/Login.css";
import decelisLogo from "../images/decelisLogo.png";
import vetorLogin from "../images/vetorLogin.png";
import Button from "react-bootstrap/Button";
import api from "../services/api";

export default function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  let navigate = useNavigate();

  function makeLogin(event) {
    event.preventDefault();
    setErrorMessage("");
    setIsLoading(true);
    api
      .post("/Login", {
        email: email,
        passwordUser: password,
      })
      .then((reply) => {
        if (reply.status === 200) {
          console.log(reply);
          localStorage.setItem("usuario-login", reply.data.createdToken);

          setPassword("");
          setEmail("");
          setIsLoading(false);

          navigate("/");
          console.log(createdToken);
        }
      })
      .catch(() => {
        setErrorMessage("E-mail e/ou Senha inválidos");
        setIsLoading(false);
      });
  }

  return (
    <div>
      <div>
        <div style={{ display: "flex" }}>
          <img className="vetorLogin" src={vetorLogin} />
          <div className="form-container">
            <form onSubmit={makeLogin} className="form">
              <div className="form-content">
                <img className="decelisLogo" src={decelisLogo} />
                <h3 className="form-title">Área do aluno</h3>
                <div className="form-group">
                  <label>Email</label>
                  <input
                    type="email"
                    className="form-control"
                    placeholder="Insira seu email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </div>
                <div className="form-group">
                  <label>Senha</label>
                  <input
                    type="password"
                    className="form-control mt-1"
                    placeholder="Insira a senha"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                  />
                  <p id="errorMessage">{errorMessage}</p>
                </div>
                <div className="d-grid gap-2 mt-3">
                  {isLoading === false ? (
                    <Button type="submit" className="btn btn-secondary">
                      Entrar
                    </Button>
                  ) : (
                    <button className="btn_carregando" type="submit" disabled>
                      Carregando...
                    </button>
                  )}
                </div>
                <p>
                  <a className="forgot-text" href="#">
                    {" "}
                    Esqueceu a senha?
                  </a>

                  <a className="forgot-text" href="/SignUp">
                    {" "}
                    Não tem cadastro?
                  </a>
                </p>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}
