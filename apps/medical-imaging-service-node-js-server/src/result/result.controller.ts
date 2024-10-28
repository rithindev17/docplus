import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { ResultService } from "./result.service";
import { ResultControllerBase } from "./base/result.controller.base";

@swagger.ApiTags("results")
@common.Controller("results")
export class ResultController extends ResultControllerBase {
  constructor(
    protected readonly service: ResultService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
