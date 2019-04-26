import React, {Component} from 'react'

import Navbar from '../../Components/Navbar-consultas/Navbar'

class AdminConsulta extends Component {
    constructor() {
        super();
        this.state = {
            listaMedicos : [] ,   
            listaPacientes: []        
        }

        this.consulta = {
            horaConsulta: '',
            dataConsulta: '',
            idPaciente: '',
            idMedico: '',
            statusConsulta: 1,
        }

    }

    componentDidMount() {
        fetch('https://spmedgroup.azurewebsites.net/api/usuarios/getmedicos',
            {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario")
                }
            })
            .then(response => response.json())
            .then(data => this.setState({listaMedicos: data}))
            .catch(erro => console.log(erro))

            fetch('https://spmedgroup.azurewebsites.net/api/usuarios/getpacientes',
            {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario")
                }
            })
            .then(response => response.json())
            .then(data => this.setState({listaPacientes: data}))
            .catch(erro => console.log(erro))
            
    }
        
    atualizarData(e) {
        this.consulta.dataConsulta = e.target.value + 'T00:00:00'
        console.log(this.consulta)
    }

    atualizarHora(e) {
        this.consulta.horaConsulta = e.target.value + ':00'
        console.log(this.consulta)
    }

    atualizarMedico(e) {
        this.consulta.idMedico = e.target.value
        console.log(this.consulta)
    }

    atualizaRPaciente(e) {
        this.consulta.idPaciente = e.target.value
        console.log(this.consulta)
    }

    cadastrar(e) {
        e.preventDefault()

        fetch('https://spmedgroup.azurewebsites.net/api/consultas',
        {   method: 'POST',
            body : JSON.stringify(this.consulta),
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("usuario")
            }
        })
        .then(data => console.log(data))
        .catch(erro => console.log(erro))
    }

    render() {
        return(
            <div className="fundo-admin">
                <Navbar/>
                <div className="card cadastrar-usuario">
                    <h1>Cadastrar Usuário</h1>
                    <h2>Informações pessoais</h2>
                    <form method="" onSubmit={this.cadastrar.bind(this)}>
                    <input  name="datanascimento"
                                className="input-cadastro" 
                                type="date" 
                                placeholder="Data de nascimento" 
                                onChange={this.atualizarData.bind(this)}
                    />
                    <br/>
                        <input type="time"
                               className="hora"
                               id="hora"
                                name="hora"
                                min="9:00" max="18:00"
                                onChange={this.atualizarHora.bind(this)}
                                required/>
                    <br/>
                    <br/>
                    <select className="select-credencial" name="" onChange={this.atualizarMedico.bind(this)} id="selecionar-credencial">
                        <option value="" defaultValue="selected">Selecione</option>
                        {this.state.listaMedicos.map(chave => {
                            return <option value={chave.id} key={chave.id}>{chave.nome}</option> 
                        })}
                    </select>
                    <br/>
                    <select className="select-credencial" name="" onChange={this.atualizaRPaciente.bind(this)} id="selecionar-credencial">
                        <option value="" defaultValue="selected">Selecione</option>
                        {this.state.listaPacientes.map(chave => {
                            return <option value={chave.id} key={chave.id}>{chave.nome}</option> 
                        })}
                    </select>
                    <br/>
                    <button type="submit" onChange={this.cadastrar.bind(this)} className="botao-cadastrar">Cadastrar</button>
                </form>
                </div>
            </div>
        )
    }
}

export default AdminConsulta