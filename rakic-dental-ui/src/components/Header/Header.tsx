import { Link } from "react-router-dom";

import "./Header.css";
const Header = () => {
  return (
    <>
      <header>
        <nav className="navbar">
          <div className="logo"></div>
          <ul className="nav-links">
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/about">About</Link>
            </li>
            <li>
              <Link to="/services">Services</Link>
            </li>
            <li>
              <Link to="/contact">Contact</Link>
            </li>
          </ul>
        </nav>
      </header>
      <h1>Ordinacija Rakic</h1>
    </>
  );
};

export default Header;
