import React, { Component } from "react";
import apiService from "../../services/api.service";

export default class EditVisitor extends Component {
  constructor(props) {
    super(props);
    this.onChangeFirstName = this.onChangeFirstName.bind(this);
    this.onChangeLastName = this.onChangeLastName.bind(this);
    this.onChangeIsMale = this.onChangeIsMale.bind(this);
    this.onChangeBirthDate = this.onChangeBirthDate.bind(this);
    this.onChangeVisitDate = this.onChangeVisitDate.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      Id: "",
      FirstName: "",
      LastName: "",
      IsMale: true,
      BirthDate: "",
      VisitDate: "",
    };
  }

  componentDidMount() {
    apiService
      .getVisitor(this.props.match.params.id)
      .then((response) => {
        console.log(response.data);
        this.setState({
          Id: response.data.id,
          FirstName: response.data.firstName,
          LastName: response.data.lastName,
          IsMale: response.data.isMale,
          BirthDate: response.data.birthDate,
          VisitDate: response.data.visitDate,
        });
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  onChangeFirstName(e) {
    this.setState({
      FirstName: e.target.value,
    });
  }

  onChangeLastName(e) {
    this.setState({
      LastName: e.target.value,
    });
  }

  onChangeBirthDate(e) {
    this.setState({
      BirthDate: e.target.value,
    });
  }

  onChangeVisitDate(e) {
    this.setState({
      VisitDate: e.target.value,
    });
  }

  onChangeIsMale(e) {
    this.setState({
      IsMale: e.target.value === "true",
    });
  }

  onSubmit(e) {
    e.preventDefault();
    const obj = {
      Id: this.state.Id,
      FirstName: this.state.FirstName,
      LastName: this.state.LastName,
      IsMale: this.state.IsMale,
      BirthDate: this.state.BirthDate,
      VisitDate: this.state.VisitDate,
    };
    console.log(obj);
    apiService
      .updateVisitor(obj)
      .then((res) => {
        console.log(res.data);
        this.props.history.push("/");
      })
      .catch((error) => console.log(error));
  }

  render() {
    return (
      <div style={{ marginTop: 10 }}>
        <h3 align="center">Редактирование записи</h3>
        <form onSubmit={this.onSubmit}>
          <div className="form-group">
            <label>Фамилия: </label>
            <input
              type="text"
              className="form-control"
              value={this.state.LastName}
              onChange={this.onChangeLastName}
            />
          </div>
          <div className="form-group">
            <label>Имя: </label>
            <input
              type="text"
              className="form-control"
              value={this.state.FirstName}
              onChange={this.onChangeFirstName}
            />
          </div>
          <div className="form-group">
            <label>Пол: </label>
            <div className="radio">
              <label>
                <input
                  type="radio"
                  value="true"
                  checked={this.state.IsMale}
                  onChange={this.onChangeIsMale}
                />
                Мужчина
              </label>
            </div>
            <div className="radio">
              <label>
                <input
                  type="radio"
                  value="false"
                  checked={!this.state.IsMale}
                  onChange={this.onChangeIsMale}
                />
                Женщина
              </label>
            </div>
          </div>

          <div className="form-group">
            <label>Дата рождения: </label>
            <input
              type="date"
              className="form-control"
              value={this.state.BirthDate}
              onChange={this.onChangeBirthDate}
            />
          </div>

          <div className="form-group">
            <label>Дата рождения: </label>
            <input
              type="datetime-local"
              className="form-control"
              value={this.state.VisitDate}
              onChange={this.onChangeVisitDate}
            />
          </div>

          <div className="form-group">
            <input
              type="submit"
              value="Сохранить"
              className="btn btn-primary"
            />
          </div>
        </form>
      </div>
    );
  }
}
