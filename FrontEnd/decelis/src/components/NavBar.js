import React, { useEffect, useState } from "react";
import decelisLogo from "../images/decelisLogoWhiteVersion.png";
import "../components/NavBar.css";
import { Navbar, Nav, Container, Button, NavDropdown } from "react-bootstrap";
import { parseJwt } from "../services/auth";
import { useNavigate } from "react-router-dom";
import api from "../services/api";

function NavBar() {
  const [nameUser, setNameUser] = useState("");
  const [userImage, setUserImage] = useState("");

  let navigate = useNavigate();

  const logout = (e) => {
    e.preventDefault();
    localStorage.removeItem("usuario-login");
    navigate("/");
  };

  function getUserInfo() {
    api("/UserInfos/" + parseJwt().jti, {
      headers: {
        Authorization: "Bearer " + localStorage.getItem("usuario-login"),
      },
    })
      .then((response) => {
        if (response.status === 200) {
          setNameUser(response.data.nameUser);
          setUserImage(
            "https://decelis.herokuapp.com/img/" + response.data.userImage
          );
        }
      })
      .catch((error) => console.error(error));
  }

  const isLogged = () => {
    const token = localStorage.getItem("usuario-login");

    if (token === null) {
      return (
        <Button href="/Login" size="lg" className="button-nav" variant="dark">
          Login
        </Button>
      );
    } else {
      return (
        <Nav className="nav-logged">
          {token !== null && parseJwt(token).role !== "1" ? (
            <>
              <Nav.Link href="/CreateUser">Gerenciamento</Nav.Link>{" "}
            </>
          ) : null}

          <Nav.Link href="/Profile">Perfil</Nav.Link>
          <img className="imageNav" src={userImage} alt="Imagem do usuário" />
          <div className="NamePicUser">
          
           
            <h6 className="userNameText">{nameUser}</h6>
            <Button
              href="/Login"
              onClick={(e) => logout(e)}
              size="lg"
              className="button-nav"
              variant="dark"
            >
              Logout
            </Button>
          </div>
        </Nav>
      );
    }
  };

  useEffect(getUserInfo, []);

  return (
    <Navbar collapseOnSelect expand="lg" className="color-nav" variant="light">
      <Container>
        <Navbar.Brand className="navbar-brand" href="/">
          <img src={decelisLogo} />
        </Navbar.Brand>

        <Navbar.Toggle
          className="toggle"
          aria-controls="responsive-navbar-nav"
        />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/">Sobre Nós</Nav.Link>
            <Nav.Link href="/">Categorias</Nav.Link>
          </Nav>
          {isLogged()}
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default NavBar;
