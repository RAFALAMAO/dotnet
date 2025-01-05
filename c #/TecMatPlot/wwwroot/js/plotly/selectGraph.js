const changeGraph = (strGraphType) => {
  class graphParams {
    constructor(graph, btn) {
      this.graph = graph;
      this.btn = btn;
    }
  }

  const params2d = new graphParams(
    document.getElementById("32638f3f-8835-4c9e-8862-8cce24881f6d"),
    document.getElementById("btn-2d")
  );
  const params3d = new graphParams(
    document.getElementById("ca66dcfa-fc39-45b5-885c-750da1b4c81f"),
    document.getElementById("btn-3d")
  );

  const hideClass = "hide";
  const activeBtnClass = "hero-active-btn";

  if (strGraphType == "2D") {
    params2d.graph.classList.remove(hideClass);
    params2d.btn.classList.add(activeBtnClass);
    params3d.graph.classList.add(hideClass);
    params3d.btn.classList.remove(activeBtnClass);
  } else if (strGraphType == "3D") {
    params2d.graph.classList.add(hideClass);
    params2d.btn.classList.remove(activeBtnClass);
    params3d.graph.classList.remove(hideClass);
    params3d.btn.classList.add(activeBtnClass);
  }
};
