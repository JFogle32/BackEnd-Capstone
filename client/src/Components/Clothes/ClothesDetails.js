import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getClothesById } from "../../Managers/ClothesManager"

export const ClothesDetails = () => {
  const [clothing, setClothing] = useState();
  const { id } = useParams();

  useEffect(() => {
    getClothesById(id).then(setClothing);
  }, [id]);

  if (!clothing) {
    return null;
  }

  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-sm-12 col-lg-6">
          <h2>{clothing.name}</h2>
          <img src={clothing.image} alt={clothing.name} style={{width: '100%', height: 'auto'}}/>
          <p><strong>Size:</strong> {clothing.size}</p>
          <p><strong>Material:</strong> {clothing.material}</p>
          <p><strong>Notes:</strong> {clothing.notes}</p>
          <p>
            <strong>Status:</strong> {clothing.status ? "Kept" : "Not Kept"}
          </p>
        </div>
      </div>
    </div>
  );
};

