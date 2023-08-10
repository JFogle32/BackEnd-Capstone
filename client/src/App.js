import React from "react";
import "./App.css";
import ClothesList from "./Components/Clothes/ClothesList";

import { BrowserRouter as Router } from "react-router-dom";

import ApplicationViews from "./Components/ApplicationViews";
import Navbar from "./Components/NavBar";

function App() {
  return (
    <div className="App">
      <Router>
        <Navbar />
        <ApplicationViews />
      </Router>
      <p>Hello</p>
    </div>
  );
}

export default App;
