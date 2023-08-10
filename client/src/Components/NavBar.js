import React from 'react';
import { Link } from 'react-router-dom';
import './Navbar.css';

const NavBar = () => {
  return (
    <nav className="navbar">
      <Link className="navbarItem" to="/">Home</Link>
      <Link className="navbarItem" to="/clothes">Clothing</Link>
      <Link className="navbarItem" to="/shoes">Shoes</Link>
      <Link className="navbarItem" to="/gadgets">Gadget</Link>
    </nav>
  );
}

export default NavBar;
