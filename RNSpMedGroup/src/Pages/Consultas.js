import React, { Component } from 'react'
import { StyleSheet, View, ScrollView, TextInput, TouchableOpacity, Text } from 'react-native'
import { FlatList } from 'react-native-gesture-handler';
import NetInfo from "@react-native-community/netinfo";
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
            connected: '',
            token: '',
            role: '',
            listaConsultas: []
        }
    }

    componentWillMount() {
        this._VerificarConexao()
    }

    _VerificarConexao = async () => {
        await NetInfo.fetch().then(state => {
            this.setState({ connected: state.isConnected })
        }
        );
        this.state.connected ? this._BuscarDados() : this._CarregarDadosOffline()

    }

    _CarregarDadosOffline = async () => {
        var Datastore = require('react-native-local-mongodb'),
            db = new Datastore({ filename: 'dadosConsultas', autoload: true });

            let lista = [];
            await db.find({}, function (err, docs) {
                if (docs == '') {
                    console.warn('nada aqui')
                } else {
                    // console.warn('docs aqui', docs)
                    lista = docs;
                }
            })
            console.warn('lista aqui 2',  lista)
            // this.render()
            // console.warn('lista aqui', this.state.listaConsultas)
    }

    _BuscarDados = async () => {
        const token = await AsyncStorage.getItem('userToken')
        const role = await AsyncStorage.getItem('userCredential')
        this.setState({ token })
        this.setState({ role })

        this._FazerRequest()
    }

    _FazerRequest = async () => {
        const resposta = await api.get('/consultas', {
            headers: {
                'Authorization': 'Bearer ' + (this.state.token)
            }
        })
        await this.setState({ listaConsultas: resposta.data })
        this._SalvarDados()
    }

    _SalvarDados() {
        var Datastore = require('react-native-local-mongodb'),
            db = new Datastore({ filename: 'dadosConsultas', autoload: true });

        let lista = this.state.listaConsultas
        db.find({}, function (err, docs) {
            if (docs == '') {
                db.insert(lista)
            } else {

                // db.find({}, function (err, docs) {
                // })
            }
        });
    }

    // _Sair() {
    //     console.warn("Sair")
    //     this.props.navigation.push("./Login")
    // }

    render() {
        console.warn('no render', this.state.listaConsultass)
        return (
            <View style={styles.container}>
                {/* <ConsultaHeader/> */}
                {/* <View style={styles.header}>
                    <Text>Opa</Text>
                    <TouchableOpacity
                        onPress={this._Sair}
                    >
                        <Text>Opa</Text>
                    </TouchableOpacity>
                </View> */}
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
    , container: {
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