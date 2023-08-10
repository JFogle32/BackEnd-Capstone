import { Routes, Route } from "react-router-dom";
import {Dashboard} from "./DashBoard";
import ClothesList from "./Clothes/ClothesList";
import { AddClothes } from "./Clothes/AddClothes";
import { ClothesDetails } from "./Clothes/ClothesDetails";
import{EditClothes} from "./Clothes/EditClothes";

const ApplicationViews = () => {
  return (
    <Routes>
      <Route path="/" element={<Dashboard />} />
      <Route path="/clothes" element={<ClothesList />} />
      <Route path="/clothes/:id" element={<ClothesDetails />} />
      <Route path="/clothes/add" element={<AddClothes />} />
      <Route path="/clothes/edit" element={<EditClothes />} />
    </Routes>
  );
};

export default ApplicationViews;
