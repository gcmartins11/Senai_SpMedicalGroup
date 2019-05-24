import React, { Component } from 'react'
import { StyleSheet, View, ScrollView, StatusBar, TouchableOpacity, Text, Image } from 'react-native'
import { FlatList } from 'react-native-gesture-handler';
import NetInfo from "@react-native-community/netinfo";
import AsyncStorage from '@react-native-community/async-storage';
import api from '../Services/Api'
import ConsultaCard from '../Components/ConsultaCard'
import logo from '../Img/logo.png'


export default class Consultas extends Component {
    static navigationOptions = {
        tabBarVisible: false,
        header: null
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
        let root = this;
        var Datastore = require('react-native-local-mongodb'),
            db = new Datastore({ filename: 'dadosConsultas', autoload: true });

        var lista = [];
        await db.find({}, function (err, docs) {
            if (docs == '') {
                console.warn('nada aqui')
            } else {
                console.warn('docs aqui', docs)
                lista = docs
            }
            console.warn('ta na lista', lista)
            root.setState({ listaConsultas: lista })
        })
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
                console.warn('jogou no banco')
                db.insert(lista)
            } else {
                db.remove({}, { multi: true }, function (err, numRemoved) {
                });
                db.insert(lista)
            }
        });
    }

    _Sair() {
        AsyncStorage.setItem('userToken', '')
        this.props.navigation.navigate("AuthStack")
    }

    render() {
        return (
            <View style={styles.container}>
                <StatusBar
                    hidden={false}
                    translucent={false}
                    backgroundColor="#cecece00"
                />
                <View style={styles.header}>
                    <Image source={logo} style={styles.image}></Image>
                    <TouchableOpacity
                        onPress={() => this._Sair()}
                    >
                        <Text style={styles.headerText}>Sair</Text>
                    </TouchableOpacity>
                </View>
                <ScrollView style={styles.scroll}>
                    {this.state.listaConsultas.map(chave => {
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
        paddingRight: 16,
        marginBottom: 12,
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
    },
    headerText: {
        color: '#fff',
        fontSize: 20,
        fontWeight: '500'
    },
    image: {
        width: 37,
        height: 40,
    },
})