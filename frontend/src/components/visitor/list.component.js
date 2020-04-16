import React, { Component } from "react";
import apiService from "../../services/api.service";
import { Link } from "react-router-dom";

export default class VisitorList extends Component {
  constructor(props) {
    super(props);
    this.delete = this.delete.bind(this);
    this.state = { items: [] };
  }


  loadItems(){
    apiService
    .getVisitors()
    .then((response) => {
      console.log(response);
      this.setState({ items: response.data });
    })
    .catch(function (error) {
      console.log(error);
    });
  }

  componentDidMount() {
    this.loadItems();
  }

  delete(id) {
    apiService
      .deleteVisitor(id)
      .then(() => {
        this.loadItems();
      })
      .catch((err) => console.log(err));
  }

  render() {
    return (
      <div>
        <h3 align="center">Список посещений</h3>
        <Link to={"/visitors/add"}>Добавить</Link>
        <table className="table table-striped" style={{ marginTop: 20 }}>
          <thead>
            <tr>
              <th>Фамилия</th>
              <th>Имя</th>
              <th>Пол</th>
              <th>Дата рождения</th>
              <th>Дата посещения</th>
              <th>Операции</th>
            </tr>
          </thead>
          <tbody>
            {this.state.items &&
              this.state.items.map((item, i) => (
                <tr key={i}>
                  <td>{item.lastName}</td>
                  <td>{item.firstName}</td>
                  <td>{item.isMale ? "Мужчина" : "Женщина"}</td>
                  <td>{item.birthDate}</td>
                  <td>{item.visitDate}</td>
                  <td>
                    <Link
                      to={"/visitors/edit/" + item.id}
                      className="btn btn-primary"
                    >
                      Редактировать
                    </Link>
                    &nbsp;
                    <button
                      onClick={this.delete.bind(this, item.id)}
                      className="btn btn-danger"
                    >
                      Удалить
                    </button>
                  </td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>
    );
  }
}
