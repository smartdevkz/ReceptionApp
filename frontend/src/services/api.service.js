import axios from "axios";

class ApiService {
  baseUrl = "https://localhost:44318/api/";

  getVisitors() {
    return this.get("visitor/");
  }

  getVisitor(id) {
    return this.get("visitor/" + id);
  }

  updateVisitor(obj) {
    return this.put("visitor/" + obj.Id, JSON.stringify(obj));
  }

  addVisitor(obj) {
    return this.post("visitor/", JSON.stringify(obj));
  }

  deleteVisitor(id) {
    return this.delete("visitor/" + id);
  }

  get(query) {
    return axios.get(this.baseUrl + query, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  put(query, json) {
    return axios.put(this.baseUrl + query, json, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  post(query, json) {
    return axios.post(this.baseUrl + query, json, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  delete(query) {
    return axios.delete(this.baseUrl + query, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  }
}

export default new ApiService();
