import React from "react";
import decelisLogo from "../images/decelisLogo.png";

function Nav() {
  return (
    <a className="LogoBase" href="/">
    <img className="decelisLogo" src={decelisLogo}/>
    </a>
  );
}

export default Nav;
