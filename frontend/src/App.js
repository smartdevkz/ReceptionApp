import React from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import VisitorsList from "./components/visitor/list.component";
import EditVisitor from "./components/visitor/edit.component";
import AddVisitor from "./components/visitor/add.component";

function App() {
  return (
    <Router>
      <div className="container">
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
          <Link to={"/"} className="navbar-brand">
            Reception App
          </Link>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav mr-auto">
              <li className="nav-item">
                <Link to={"/visitors"} className="nav-link">
                  Посещения
                </Link>
              </li>
            </ul>
          </div>
        </nav>{" "}
        <br />
        <Switch>
          <Route path="/visitors/edit/:id" component={EditVisitor} />
          <Route path="/visitors/add" component={AddVisitor} />
          <Route path="/visitors/" component={VisitorsList} />
          <Route path="/" component={VisitorsList} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;
