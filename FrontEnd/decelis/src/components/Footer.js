import React, { useState } from "react";
import "./Footer.css";
import logo from "../images/decelisLogo.png";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";

export default function Footer() {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <div className="allfooter">
      <div className="logo-and-text">
        <a href="/">
        <img
         
          src={logo}
          className="footer-logo"
          alt="logo decelis"
        />
        </a>
        <a>Decelis @ 2022</a>
      </div>
      <div className="texts">
        <a href="#carousel-info">Sobre Nós</a>
        <a href="#modal" onClick={handleShow}>
          Politicas de Privacidade
        </a>
        <ul className="social_media">
          <li>
            <a href="#">
              <span className="material-icons md24">mail</span>
            </a>
          </li>
          <li>
            <a href="#">
              <span className="material-icons md24">facebook</span>
            </a>
          </li>
          <li>
            <a href="#">
              <span className="material-icons md24">slideshow</span>
            </a>
          </li>
          <li>
            <a href="#">
              <span className="material-icons md24">alternate_email</span>
            </a>
          </li>
          <li>
            <a href="#">
              <span className="material-icons md24">photo_camera</span>
            </a>
          </li>
        </ul>
      </div>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Política Privacidade</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <>
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              A sua privacidade é importante para nós. É política da Decelis
              respeitar a sua privacidade em relação a qualquer informação sua
              que possamos coletar no site da <a href="">Decelis</a>, e outros
              sites que possuímos e operamos.
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Solicitamos informações pessoais apenas quando realmente
              precisamos delas para lhe fornecer um serviço. Fazemo-lo por meios
              justos e legais, com o seu conhecimento e consentimento. Também
              informamos por que estamos coletando e como será usado.
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Apenas retemos as informações coletadas pelo tempo necessário para
              fornecer o serviço solicitado. Quando armazenamos dados,
              protegemos dentro de meios comercialmente aceitáveis ​​para evitar
              perdas e roubos, bem como acesso, divulgação, cópia, uso ou
              modificação não autorizados.
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Não compartilhamos informações de identificação pessoal
              publicamente ou com terceiros, exceto quando exigido por lei.
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              O nosso site pode ter links para sites externos que não são
              operados por nós. Esteja ciente de que não temos controle sobre o
              conteúdo e práticas desses sites e não podemos aceitar
              responsabilidade por suas respectivas&nbsp;
              <a
                style={{
                  boxSizing: "border-box",
                  color: "#055af9",
                  textDecorationLine: "none",
                  backgroundColor: "transparent",
                }}
                href="https://politicaprivacidade.com/"
                target="_BLANK"
              >
                políticas de privacidade
              </a>
              .
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Você é livre para recusar a nossa solicitação de informações
              pessoais, entendendo que talvez não possamos fornecer alguns dos
              serviços desejados.
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              O uso continuado de nosso site será considerado como aceitação de
              nossas práticas em torno de{" "}
              <a
                href="https://avisodeprivacidad.info/"
                rel="nofollow"
                target="_BLANK"
                style={{
                  color: "inherit !important",
                  textDecoration: "none !important",
                  fontSize: "inherit !important",
                }}
              >
                Aviso de Privacidad
              </a>{" "}
              e informações pessoais. Se você tiver alguma dúvida sobre como
              lidamos com dados do usuário e informações pessoais, entre em
              contacto connosco.
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            />{" "}
            <h3
              style={{
                boxSizing: "border-box",
                margin: "0px 0px 20px",
                lineHeight: "1.2",
                fontSize: 16,
                letterSpacing: "-0.05em",
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Compromisso do Usuário
            </h3>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              O usuário se compromete a fazer uso adequado dos conteúdos e da
              informação que o Decelis oferece no site e com caráter
              enunciativo, mas não limitativo:
            </p>{" "}
            <ul
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                fontSize: 16,
                backgroundColor: "#ffffff",
              }}
            >
              {" "}
              <li style={{ boxSizing: "border-box" }}>
                A) Não se envolver em atividades que sejam ilegais ou contrárias
                à boa fé a à ordem pública;
              </li>{" "}
              <li style={{ boxSizing: "border-box" }}>
                B) Não difundir propaganda ou conteúdo de natureza racista,
                xenofóbica,{" "}
                <a
                  href="https://ondeapostar.com/betano-e-confiavel"
                  rel="nofollow"
                  target="_BLANK"
                  style={{
                    color: "inherit !important",
                    textDecoration: "none !important",
                    fontSize: "inherit !important",
                  }}
                >
                  {" "}
                  betano
                </a>{" "}
                ou azar, qualquer tipo de pornografia ilegal, de apologia ao
                terrorismo ou contra os direitos humanos;
              </li>{" "}
              <li style={{ boxSizing: "border-box" }}>
                C) Não causar danos aos sistemas físicos (hardwares) e lógicos
                (softwares) do Decelis, de seus fornecedores ou terceiros, para
                introduzir ou disseminar vírus informáticos ou quaisquer outros
                sistemas de hardware ou software que sejam capazes de causar
                danos anteriormente mencionados.
              </li>{" "}
            </ul>{" "}
            <h3
              style={{
                boxSizing: "border-box",
                margin: "0px 0px 20px",
                lineHeight: "1.2",
                fontSize: 16,
                letterSpacing: "-0.05em",
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Mais informações
            </h3>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Esperemos que esteja esclarecido e, como mencionado anteriormente,
              se houver algo que você não tem certeza se precisa ou não,
              geralmente é mais seguro deixar os cookies ativados, caso interaja
              com um dos recursos que você usa em nosso site.
            </p>{" "}
            <p
              style={{
                boxSizing: "border-box",
                marginTop: 0,
                marginBottom: "1rem",
                fontSize: 16,
                color: "#576d96",
                fontFamily: "Montserrat, sans-serif",
                backgroundColor: "#ffffff",
              }}
            >
              Esta política é efetiva a partir de{" "}
              <strong>1 agosto 2022 13:00</strong>
            </p>
          </>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Fechar
          </Button>
          <Button variant="primary" onClick={handleClose}>
            Entendi
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
