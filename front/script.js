const apiUrl = "http://localhost:5000";

const dadosForm = document.querySelectorAll('#dadosForm')

let creatAt = new Date();
console.log(creatAt.toISOString().slice(0, 19))

let newData = creatAt.toLocaleString('us-en').replace(' ', 'T');
console.log(newData);

function exibirDado() {
    dadosForm.forEach(dado => console.log(dado.value))
}

// fetch(apiUrl + "/api/v1/formulario")
//     .then(res => (res.json())
//         .then(data => {
//             console.log(data)
//         })
//     )

async function buscarDado() {
    const dataClient = await axios.get('http://localhost:5000/api/v1/formulario/sdsd')
    console.log(dataClient, "tttttt")
}


async function insertDado() {
    try {
        let creatAt = new Date();

        const data = {
            "nome": dadosForm[0].value,
            "cnpj": dadosForm[1].value,
            "email": dadosForm[2].value,
            "telefone": dadosForm[3].value,
            "instituicaoApoio": dadosForm[4].value,
            "id": null,
            // "criado": "2020-01-01T00:00:00",
            "criado": creatAt.toISOString().slice(0, 19),
            "modificado": null,
            "excluido": null
        }

        // let fetchData = {
        //     method: "POST",
        //     body: JSON.stringify(data),
        //     headers: {
        //         "Content-Type": "application/json",
        //     },
        // };

        // fetch(apiUrl + "/api/v1/formulario", fetchData) 
        //     .then(res => res.json())
        //     .then(data => {
        //         console.log(data);
        //     })

        if (data.nome === "" || data.cnpj === "") {
            alert("Preencha nome e cnpj");
        } else {
            const dataClient = await axios.post('http://localhost:5000/api/v1/formulario/', data)
            if (dataClient.status === 201) {
                data.id = dataClient.data.id
                console.log(dataClient, "aaaaaaaaaaaaaaaaa")
                alert("Empresa cadastrada com sucesso");
            } else {
                alert("Erro ao salvar")
            }
        }

    } catch (error) {
        console.log(error.response)
    }

}

// insertDado();

// api.get("api/v1/formulario").then(items => {
//     console.log(items);
// })