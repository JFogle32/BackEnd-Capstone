import React from "react";

export const Clothes = ({ clothes }) => {
  return (
    <div className="clothesDetail">
      <h2>{clothes.name}</h2>
      <p><strong>Size:</strong> {clothes.size}</p>
      <p><strong>Status:</strong> {clothes.status} </p> ? 
      {clothes.image && <img src={clothes.image} alt={clothes.name} />}
      <p><strong>Material:</strong> {clothes.material}</p>
      <p><strong>Notes:</strong> {clothes.notes}</p>
    </div>
  );
};
