
const baseUrl = '/api/Clothes';

export const getAllClothes = () => {
  return fetch(baseUrl) 
    .then((res) => res.json())
};

export const getClothesById = (id) => { 
  return fetch(`${baseUrl}/${id}`)
    .then((res) => res.json())
};

export const addClothes = (clothes) => { 
  return fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(clothes),
  });
};

export const updateClothes = (id, clothes) => {
  return fetch(`${baseUrl}/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(clothes),
  });
};

export const deleteClothes = (id) => {
  return fetch(`${baseUrl}/${id}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  });
};