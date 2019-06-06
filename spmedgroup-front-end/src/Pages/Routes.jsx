import React from 'react'
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';

import Login from './Login/Login'
import Consultas from './Consultas/Consultas'
import AdminUsuario from './Admin/AdminUsuario'
import AdminConsulta from './Admin/AdminConsulta'
import Localizacoes from './Localizacoes/Localizacoes'
import LocalizacoesDetalhes from './Localizacoes/LocalizacoesDetalhes'

export default props =>
<Router>
    <Switch>
        <Route exact path="/login" component={Login}/>
        <Route path="/Consultas" component={Consultas}/>
        <Route path="/admin/usuario" component={AdminUsuario}/>
        <Route path="/admin/consulta" component={AdminConsulta}/>
        <Route path="/localizacoes" component={Localizacoes}/>
        <Route path="/localizacoesDetalhes" component={LocalizacoesDetalhes}/>
        <Redirect from="*" to="/login"/>
    </Switch>
</Router>