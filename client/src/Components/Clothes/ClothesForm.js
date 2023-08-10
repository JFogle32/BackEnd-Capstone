// import React, { useState } from "react";
// import {CLothesManager.js} from "./ClothesManager.js"; 
// import { useNavigate } from "react-router-dom";

// export const ClothesForm = () => {

//     const [newClothes, update] = useState({
//         name: "",
//         size: "",
//         status: false,
//         image: "",
//         material: "",
//         notes: "",
//         userId: 1,
//     });

//     const navigate = useNavigate();

//     const handleSaveButtonClick = (event) => {
//         event.preventDefault();
//         const clothesToSendToAPI = {
//             Name: newClothes.name,
//             Size: newClothes.size,
//             Status: newClothes.status,
//             Image: newClothes.image,
//             Material: newClothes.material,
//             Notes: newClothes.notes,
//             UserId: 1,
//         };

//         return addClothes(clothesToSendToAPI)
//                 .then(() => navigate("/clotheslist"));
//     };

//     return (
//         <form className="clothes-form">
//             <h2 className="clothes-form-title">Add New Clothes</h2>

//             <fieldset>
//                 <div className="form-group">
//                     <label htmlFor="name">Name of Clothes:</label>
//                     <input
//                         type="text"
//                         id="name"
//                         value={newClothes.name}
//                         onChange={(event) => {
//                             const copy = { ...newClothes };
//                             copy.name = event.target.value;
//                             update(copy);
//                         }} 
//                     />
//                 </div>
//             </fieldset>

//             <fieldset>
//                 <div className="form-group">
//                     <label htmlFor="size">Size:</label>
//                     <input
//                         type="text"
//                         id="size"
//                         value={newClothes.size}
//                         onChange={(event) => {
//                             const copy = { ...newClothes };
//                             copy.size = event.target.value;
//                             update(copy);
//                         }} 
//                     />
//                 </div>
//             </fieldset>

//             <fieldset>
//                 <div className="form-group">
//                     <label htmlFor="image">Image URL:</label>
//                     <input
//                         type="text"
//                         id="image"
//                         value={newClothes.image}
//                         onChange={(event) => {
//                             const copy = { ...newClothes };
//                             copy.image = event.target.value;
//                             update(copy);
//                         }} 
//                     />
//                 </div>
//             </fieldset>

//             <fieldset>
//                 <div className="form-group">
//                     <label htmlFor="material">Material:</label>
//                     <input
//                         type="text"
//                         id="material"
//                         value={newClothes.material}
//                         onChange={(event) => {
//                             const copy = { ...newClothes };
//                             copy.material = event.target.value;
//                             update(copy);
//                         }} 
//                     />
//                 </div>
//             </fieldset>

//             <fieldset>
//                 <div className="form-group">
//                     <label htmlFor="notes">Notes:</label>
//                     <textarea
//                         id="notes"
//                         value={newClothes.notes}
//                         onChange={(event) => {
//                             const copy = { ...newClothes };
//                             copy.notes = event.target.value;
//                             update(copy);
//                         }} 
//                     />
//                 </div>
//             </fieldset>

//             <fieldset>
//                 <div className="form-group">
//                     <label>
//                         <input
//                             type="checkbox"
//                             checked={newClothes.status}
//                             onChange={() => {
//                                 const copy = { ...newClothes };
//                                 copy.status = !copy.status;
//                                 update(copy);
//                             }} 
//                         />
//                         Kept
//                     </label>
//                 </div>
//             </fieldset>

//             <button
//                 onClick={(clickEvent) => handleSaveButtonClick(clickEvent)} 
//                 className="btn btn-primary">
//                 Add Clothes
//             </button>
//         </form>
//     );
// };
