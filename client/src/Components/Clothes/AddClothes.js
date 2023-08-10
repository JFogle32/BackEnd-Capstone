import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom"
import { addClothes } from "../../Managers/ClothesManager";
import { Button } from "reactstrap";

export const AddClothes = () => {
  const [clothes, update] = useState({
   name: "",
   size: "",
   status: false,
   image: "",
   material: "",
   notes: "",
   userId: 1,
})

const navigate = useNavigate()
const handleSaveButtonClick = (event) => {
        event.preventDefault()
        const clothesToAPI = {
            Name: clothes.name,
            Size: clothes.size,
            Status: clothes.status,
            Image: clothes.image,
            Material: clothes.material,
            Notes: clothes.notes,
            UserId: 1,
        };
    return addClothes(clothesToAPI)
        .then(navigate("/clothes"));
};

return (
    <form className="clothesForm">
        <h2 className="clothesForm__title">New Clothes</h2>
        <fieldset>
            <div className="form-group">
                <label htmlFor="name">Name of Clothes:</label>
                <input
                    required autoFocus
                    type="text"
                    className="form-control"
                    placeholder="Enter clothes name"
                    value={clothes.name}
                    onChange={(event) => {
                        const copy = {...clothes}
                        copy.name = event.target.value 
                        update(copy)
                    }} 
                />

                <label htmlFor="size">Size:</label>
                <input
                    type="text"
                    className="form-control"
                    placeholder="Enter size"
                    value={clothes.size}
                    onChange={(event) => {
                        const copy = {...clothes}
                        copy.size = event.target.value 
                        update(copy)
                    }} 
                />

                <label htmlFor="status">Status:</label>
                <input
                    type="checkbox"
                    className="form-control"
                    value={clothes.status}
                    onChange={(event) => {
                        const copy = {...clothes}
                        copy.status = event.target.checked
                        update(copy)
                    }} 
                />

                <label htmlFor="image">Image URL:</label>
                <input
                    type="text"
                    className="form-control"
                    placeholder="Enter image url"
                    value={clothes.image}
                    onChange={(event) => {
                        const copy = {...clothes}
                        copy.image = event.target.value 
                        update(copy)
                    }} 
                />

                <label htmlFor="material">Material:</label>
                <input
                    type="text"
                    className="form-control"
                    placeholder="Enter material"
                    value={clothes.material}
                    onChange={(event) => {
                        const copy = {...clothes}
                        copy.material = event.target.value 
                        update(copy)
                    }} 
                />

                <label htmlFor="notes">Notes:</label>
                <textarea
                    className="form-control"
                    placeholder="Enter notes"
                    value={clothes.notes}
                    onChange={(event) => {
                        const copy = {...clothes}
                        copy.notes = event.target.value 
                        update(copy)
                    }} 
                />
            </div>
        </fieldset>

        <Button 
        onClick={(clickEvent) => handleSaveButtonClick(clickEvent)}
            className="btn btn-primary">
           Save
        </Button>
    </form>)}
    