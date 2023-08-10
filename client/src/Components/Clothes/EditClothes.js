import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getClothesById, updateClothes } from "../../Managers/ClothesManager";

export const EditClothes = () => {
  const [clothing, setClothing] = useState({});
  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    getClothesById(id).then(setClothing);
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setClothing(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleEditClothes = () => {
    updateClothes(id, clothing).then(() => navigate("/clothes"));
  };

  return (
    <div className="container">
      <h2>Edit Clothes</h2>
      <form>
        <div>
          <label>Name:</label>
          <input type="text" name="name" value={clothing.name || ""} onChange={handleChange} />
        </div>
        <div>
          <label>Size:</label>
          <input type="text" name="size" value={clothing.size || ""} onChange={handleChange} />
        </div>
        <div>
          <label>Material:</label>
          <input type="text" name="material" value={clothing.material || ""} onChange={handleChange} />
        </div>
        <div>
          <label>Image:</label>
          <input type="text" name="image" value={clothing.image || ""} onChange={handleChange} />
        </div>
        <div>
          <label>Notes:</label>
          <textarea name="notes" value={clothing.notes || ""} onChange={handleChange}></textarea>
        </div>
        <div>
          <label>Status:</label>
          <select name="status" value={clothing.status || ""} onChange={handleChange}>
            <option value={true}>Kept</option>
            <option value={false}>Not Kept</option>
          </select>
        </div>
        <button type="button" onClick={handleEditClothes}>Update Clothes</button>
      </form>
    </div>
  );
};

export default EditClothes;
