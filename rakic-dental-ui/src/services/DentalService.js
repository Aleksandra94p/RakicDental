export const getDentists = () => {
    fetch("https://localhost:44389/api/Dentists", {
        method: "GET",
      })
        .then((response) => response.json())
}

