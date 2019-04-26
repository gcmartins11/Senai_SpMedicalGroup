import React from 'react'
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';

import Login from './Login/Login'
import Consultas from './Consultas/Consultas'
import Admin from './Admin/Admin'
import AdminConsulta from './Admin/AdminConsulta'

export default props =>
<Router>
    <Switch>
        <Route exact path="/login" component={Login}/>
        <Route path="/Consultas" component={Consultas}/>
        <Route path="/admin/usuario" component={Admin}/>
        <Route path="/admin/consulta" component={AdminConsulta}/>
        <Redirect from="*" to="/login"/>
    </Switch>
</Router>