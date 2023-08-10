import React from "react";
import { Link } from "react-router-dom";
import  ClothesList  from "./Clothes/ClothesList";

export const Dashboard = () => {
  return (
    <div>
      <h1>Dashboard</h1>
      <div>
        <h2>Shoes</h2>
        {/* <ShoesList /> */}
        <Link to="/shoes/add">Add New Shoe</Link>
      </div>
      <div>
        <h2>Clothes</h2>
        {/* <ClothesList /> */}
        <Link to="/clothes/add">Add New Cloth</Link>
      </div>
      <div>
        <h2>Gadgets</h2>
        {/* <GadgetList /> */}
        <Link to="/gadgets/add">Add New Gadget</Link>
      </div>
    </div>
  );
};


