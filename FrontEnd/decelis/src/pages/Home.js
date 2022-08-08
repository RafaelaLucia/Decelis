import React from "react";
import "../styles/Home.css";
import NavBar from "../components/NavBar";
import Footer from "../components/Footer";
import { Carousel } from "react-bootstrap";
import Carousel1 from "../images/carousel1.jpg";
import Carousel2 from "../images/carousel2.jpg";
import Carousel3 from "../images/carousel3.jpg";
import Ballerinas from "../images/Students.jpg";

export default function Home() {
  return (
    <div>
      <NavBar />
      <div style={{ marginTop: "50px" }}>
        <div className="overlap-fixed">
          <h2 id="carousel-info" className="text-center overlap-title">
            BALLET PARA TODAS AS IDADES <br /> AULAS LIVRES OU CURSO
          </h2>
          <h3 className="text-center overlap-text">
            Você pode fazer Ballet com diversos objetivos: ganhar flexibilidade{" "}
            <br /> e alongamento, aprender ou aperfeiçoar a técnica do ballet,{" "}
            <br /> melhorar a postura, fazer uma atividade física e <br />{" "}
            mental saudável e mais!
          </h3>
        </div>
        <Carousel fade interval={5000} controls={false} indicators={false}>
          <Carousel.Item>
            <img
              className="img-carousel d-block w-100"
              src={Carousel1}
              alt="Grupo de bailarinas"
            />
          </Carousel.Item>
          <Carousel.Item>
            <img
              className="img-carousel d-block w-100"
              src={Carousel2}
              alt="Grupo se apresentando num palco"
            />
          </Carousel.Item>
          <Carousel.Item>
            <img
              className="img-carousel d-block w-100"
              src={Carousel3}
              alt="Professora de ballet conversando com suas alunas infantis"
            />
          </Carousel.Item>
        </Carousel>
      </div>
      <div className="about-us">
        <img className="principal-image" src={Ballerinas} />
        <div className="brown-square">
          <h2 id="classes">
            Aulas disponíveis para os seguintes níveis: <br /> <br />
            Baby Class - 4 anos <br />
            Preparatório I - 5 e 6 anos <br /> Preparatório II - 6 e 7 anos{" "}
            <br /> <br /> • Iniciante Intermediário • <br /> Grau I - 8 e 9 anos{" "}
            <br /> Grau II - 9 anos (com experiência), 10 e 11 anos <br /> Grau
            III - 11 e 12 anos (com experiência) <br />
            Grau IV - 13 anos <br /> Grau V - 13 e 14 anos <br /> <br /> •
            Avançado • <br /> 1º Ano Técnico - 14 anos <br /> 2º Ano Técnico -
            14 e 15 anos <br /> 3º Ano Técnico - Corpo de Baile - 15 e 16 anos{" "}
          </h2>
        </div>
      </div>
      <div className="spacing"></div>
      <Footer />
    </div>
  );
}
