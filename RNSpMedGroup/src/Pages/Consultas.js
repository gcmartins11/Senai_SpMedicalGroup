import React, { Component } from 'react'
import { StyleSheet, View, ScrollView, TextInput, Button, Text } from 'react-native'
import { FlatList } from 'react-native-gesture-handler';
import AsyncStorage from '@react-native-community/async-storage';
import api from '../Services/Api'
import ConsultaCard from '../Components/ConsultaCard'


export default class Consultas extends Component {
    static navigationOptions = {
        tabBarVisible: false
    };

    constructor(props) {
        super(props)
        this.state = {
            token: '',
            role: '',
            listaConsultas: []
        }
    }

    componentDidMount() {
        this._BuscarDados()
    }

    _BuscarDados = async () => {
        const token = await AsyncStorage.getItem('userToken')
        const role = await AsyncStorage.getItem('userCredential')
        this.setState({ token })
        this.setState({ role })
        // console.warn(token)
        // console.warn(this.state.role)

        this._FazerRequest()
    }

    _FazerRequest = async () => {
        const resposta = await api.get('/consultas', {
            headers: {
                'Authorization': 'Bearer ' + (this.state.token)
            }
        })
        AsyncStorage.setItem('listaConsultas', resposta.data)
        this.setState({listaConsultas: resposta.data})

        this.MostrarLista()
    } 

    MostrarLista = async() => {
        const lista = await AsyncStorage.getItem('listaConsultas')
        console.warn(lista)
    }

    render() {
        return (
            <View style={styles.container}>
                <ScrollView style={styles.scroll}>
                    {this.state.listaConsultas.map(chave => {
                        // console.warn(chave)
                        return <ConsultaCard 
                                    especialidade={chave.especialidade}
                                    medico={chave.nomeMedico}
                                    paciente={chave.nomePaciente}
                                    data={chave.dataConsulta}
                                    hora={chave.horaConsulta}
                                    status={chave.status}
                                />
                    })}
                </ScrollView>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: 'white',
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        // alignItems: 'center',
        margin: 0,
        padding: 0
    },
    scroll: {
        flex:1,
        width: '102%',
        marginLeft: 15
    }
})