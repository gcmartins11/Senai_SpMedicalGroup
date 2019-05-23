import React, { Component } from 'react'
import { StyleSheet, View, ScrollView, TextInput, TouchableOpacity, Text } from 'react-native'
import { FlatList } from 'react-native-gesture-handler';
import AsyncStorage from '@react-native-community/async-storage';
import api from '../Services/Api'
import ConsultaCard from '../Components/ConsultaCard'
import ConsultaHeader from '../Components/ConsultaHeader'


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
        this.setState({ listaConsultas: resposta.data })
        console.warn(resposta)
    }

    _Sair() {
        console.warn("Sair")
        this.props.navigation.push("./Login")
    }

    render() {
        return (
            <View style={styles.container}>
                {/* <ConsultaHeader/> */}
                <View style={styles.header}>
                    <Text>Opa</Text>
                    <TouchableOpacity
                        onPress={this._Sair}
                    >
                        <Text>Opa</Text>
                    </TouchableOpacity>
                </View>
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
    header: {
        width: '100%',
        height: 56,
        alignItems: 'center',
        justifyContent: 'space-between',
        flexDirection: 'row',
        backgroundColor: '#13C9AA',
        paddingLeft: 16,
        paddingRight: 16
    }
,    container: {
        backgroundColor: 'white',
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        // alignItems: 'center',
        margin: 0,
        padding: 0
    },
    scroll: {
        flex: 1,
        width: '102%',
        marginLeft: 15
    }
})