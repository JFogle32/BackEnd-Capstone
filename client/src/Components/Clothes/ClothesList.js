import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { getAllClothes, deleteClothes } from "../../Managers/ClothesManager";

const ClothesList = () => {
  const [clothes, setClothes] = useState([]);

  useEffect(() => {
    refreshClothesList();
  }, []);

  const refreshClothesList = () => {
    getAllClothes().then(setClothes);
  }

  const handleDeleteClothes = (id) => {
    deleteClothes(id).then(() => refreshClothesList());
  };

  return (
    <div>
      <div>
        <h2>Clothes</h2>
        <Link to="/clothes/add">Add New Cloth</Link>
      </div>
      {clothes.map((item) => (
        <div key={item.id}>
          <h3>{item.name}</h3>
          <Link to={`/clothes/${item.id}`}>Details</Link>
          {" | "}
          <Link to={`/clothes/edit/${item.id}`}>Edit</Link>
          {" | "}
          <button onClick={() => handleDeleteClothes(item.id)}>Delete</button>
        </div>
      ))}
    </div>
  );
};

export default ClothesList;
